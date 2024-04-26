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
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _services;
        public AuthenticationController(IServiceManager services)
        {
            _services = services;
        }

        [HttpPost]

        //[ServiceFilter(typeof((ValidationFilterAttribute)))]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistrationDto)
        {
            var result = await _services.AuthenticationService.RegisterUser(userForRegistrationDto);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }

        [HttpPost("login")]
       // [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)

        {
            if (!await _services.AuthenticationService.ValidateUser(user))
                return Unauthorized();
            return Ok(new
            {
                Token = await _services.AuthenticationService.CreateToken()

            });
        }
    }
}
