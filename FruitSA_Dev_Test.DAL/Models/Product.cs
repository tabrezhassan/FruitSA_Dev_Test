using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FruitSA_Dev_Test.DAL.Models
{
    public class Product
    {
        [Key]
        public string ProductId { get; set; } = string.Empty;
        public string ProductCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string CategoryName { get; set; } = string.Empty;

        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }
        public byte[]  Image { get; set; } = new byte[0];

        public virtual Category Category { get; set; }
    }
}
