using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stock.Entities
{
    public class ProductStock
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        [ConcurrencyCheck]
        public string VariantCode { get; set; }

        [StringLength(50)]
        [ConcurrencyCheck]
        public string ProductCode { get; set; }

        [ConcurrencyCheck]
        public int Quantity { get; set; }
    }
}
