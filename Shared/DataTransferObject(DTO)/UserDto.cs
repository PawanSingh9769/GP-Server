using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject_DTO_
{
    public record UserDto(
          string FirstName,

          string LastName ,

          [Required(ErrorMessage = "Username is required")]
          string UserName ,

          [Required(ErrorMessage = "Password is required")]
    
           string Email ,

           string PhoneNumber
    );
}
