using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Seller
    {
        [Column("SellerId")]
        //[Key] // Indicates this property as the primary key
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ContactInformation { get; set; }

        // Navigation property for products
        public ICollection<Product>? Products { get; set; }
    }
}
