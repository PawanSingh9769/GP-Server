using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject_DTO_
{
    public record ProductDto(Guid Id, string ProductName, string ProductDescription, decimal Price, Guid SellerId);
}
