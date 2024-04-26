using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contract;
using Shared.DataTransferObject_DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProductifyBackend.Presentation.Controllers
{
    [Route("api/sellers")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly IServiceManager _service;
        public SellerController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllSellerAsync()
        {
            try
            {
                var sellers = await _service.SellerService.GetAllSellerAsync(trackChanges: false);
                return Ok(sellers);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }


        //Add Seller
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateSeller([FromBody] SellerForCreationDto seller)
        {
            if (seller == null)
            {
                return BadRequest("SellerforCreation Object is null ");

            }
            var createdSeller = await _service.SellerService.CreateSeller(seller);
            return CreatedAtRoute("SellerById", new { id = createdSeller.Id }, createdSeller);
        }

        [HttpGet("{id:guid}" ,Name = "SellerById")]
        //[Authorize]
        public async Task<IActionResult> GetSeller(Guid id)
        {
            try
            {
                var seller = await _service.SellerService.GetSellerAsync(id, trackChanges: false);
                return Ok(seller);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateSeller(Guid id , [FromBody] SellerForCreationDto sellerForUpdateDto)
        {
            if(sellerForUpdateDto == null)
            {
                return BadRequest("Something went wrong");

            }

             await _service.SellerService.UpdateSellerById(id, sellerForUpdateDto, trackChanges: false);
            return Ok("updated successfully");

        }
    }
}
