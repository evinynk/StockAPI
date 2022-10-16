### create the build instance
##FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
##
##WORKDIR /source
##COPY /. ./
##
###restore
##RUN dotnet restore
##
### build with configuration
##RUN dotnet build ../../src/Stock.API/StockAPI.csproj -c Release
##
##RUN dotnet publish ../../src/Stock.API/StockAPI.csproj -c Release -o /src/output
##
### create the runtime instance
##FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine AS runtime
##
### add globalization support
##RUN apk add --no-cache icu-libs
##ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
##
### installs required packages
##RUN apk add libgdiplus --no-cache --repository http://dl-3.alpinelinux.org/alpine/edge/testing/ --allow-untrusted
##RUN apk add libc-dev --no-cache
##
##COPY --from=build /src/output .
##
##ENTRYPOINT ["dotnet", "StockAPI.dll"]
#
#
#FROM mcr.microsoft.com/dotnet/core/runtime:2.2-stretch-slim AS base
#
#WORKDIR /app
#
#EXPOSE PortNumberOpenedOnDatabaseServer
#
#
#FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
#
#WORKDIR /src
#
#COPY ["Stock.API.csproj", "StockAPI/"]
#
#RUN dotnet restore "./Stock.API.csproj"
#
#COPY . .
#
#WORKDIR "/src/."
#
#RUN dotnet build "Stock.API.csproj" -c Release -o /app/build
#
#
#
#FROM build AS publish
#
#RUN dotnet publish "Stock.API.csproj" -c Release -o /app/publish
#
#
#
#FROM base AS final
#
#WORKDIR /app
#
#COPY --from=publish /app/publish .
#
#ENTRYPOINT ["dotnet", "Stock.API.dll"]


# Stage 1: build the source in a container by using the microsoft/aspnetcore-build image (it comes with the .NET CORE SDK)
FROM microsoft/aspnetcore-build AS builder
WORKDIR /source

# caches restore result by copying csproj file separately
COPY Stock.API.csproj .
RUN dotnet restore

# copies the rest of your code
COPY . .
RUN dotnet publish --output /app/ --configuration Release

# Stage 2: move and run the build output to an environment which is more similar to production (just the .NET Core runtime installed)
FROM microsoft/aspnetcore
WORKDIR /app
COPY --from=builder /app .
ENV ASPNETCORE_ENVIRONMENT Production
ENTRYPOINT ["dotnet", "Stock.API.dll"]