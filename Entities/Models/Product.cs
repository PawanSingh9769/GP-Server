using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public  class Product
    {
        [Column("ProductId")]
        //[Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "product name is a required field")]
        [MaxLength(60, ErrorMessage = "Maximum length for the name is 60 char")]
        public string? ProductName { get; set; }

        [Required(ErrorMessage = "product Description is a required field")]
        
        public string? ProductDescription { get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [ForeignKey(nameof(Seller))]
        public Guid SellerId { get; set; }

        //Navigation property 
        public Seller? seller { get; set; }  // navigate from product to seller
    }
}
