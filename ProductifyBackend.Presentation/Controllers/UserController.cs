using Microsoft.AspNetCore.Mvc;
using Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductifyBackend.Presentation.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly IServiceManager _service;
        public UserController(IServiceManager service)
        {
            _service = service;
            
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _service.UserService.GetAllUsers(trackChanges:false);
            return Ok(users);
        }
    }
}
