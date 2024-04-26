using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contract;
using Shared.DataTransferObject_DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductifyBackend.Presentation.Controllers
{
    [Route("api/sellers/{sellerId}/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ProductController(IServiceManager service )
        {
            _service = service;
            
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllProductAsync(Guid sellerId)
        {
            try
            {
                var products = await _service.ProductService.GetAllProductsAsync(sellerId, trackChanges: false);
                return Ok(products);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateProduct(Guid sellerId, [FromBody] ProductForCreationDto product)
        {
            if(product == null)
            {
                return BadRequest("EmployeeForCreation Object is null");
            }

            var employeeToReturn = await _service.ProductService.CreateProductAsync(sellerId , product , trackChanges: false);
            return Ok(employeeToReturn);

        }
    }
}
