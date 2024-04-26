using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject_DTO_
{
    
    public record ProductForCreationDto(
     [Required(ErrorMessage = "Product name is required.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the name is 60 characters.")]
     string ProductName ,

    [Required(ErrorMessage = "Product description is required.")]
    string ProductDescription,

    [Required(ErrorMessage = "Price is required.")]
    decimal Price,

    [Required(ErrorMessage = "Seller Id is required.")]
    Guid SellerId
        );

       
    
}
