using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FruitSA_Dev_Test.DAL.Models
{
    public class Category
    {
        [Required]
        public string CategoryId { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string CategoryCode { get; set; } = string.Empty;

        [Required]
        public bool IsActive { get; set; } = false;

        //public virtual ICollection<Product> Products { get; set; }
    }
}
