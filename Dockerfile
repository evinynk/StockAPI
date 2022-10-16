FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-bionic AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS build
WORKDIR /src
COPY ["Stock.API/Stock.API.csproj", "Stock.API.Core/"]
COPY ["Stock.Business/Stock.Business.csproj", "Stock.Business/"]
COPY ["Stock.DataAccess/Stock.DataAccess.csproj", "Stock.DataAccess/"]
COPY ["Stock.Entities/Stock.Entities.csproj", "Stock.Entities/"]
COPY ["Stock.UnitTests/Stock.UnitTests.csproj", "Stock.UnitTests/"]

COPY . .
WORKDIR "/src/Stock.API"

FROM build AS publish
RUN dotnet publish "Stock.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Stock.API.dll"]
