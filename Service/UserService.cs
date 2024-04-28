using AutoMapper;

using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Service.Contract;
using Shared.DataTransferObject_DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class UserService : IUserService
    {
        private readonly ILoggerManager _logger;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private User? _user;
        public UserService(ILoggerManager logger, UserManager<User> userManager, IConfiguration configuration, IMapper mapper)
        {
            
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;


        }

        public async Task<IEnumerable<UserDto>> GetAllUsers(bool trackChanges)
        {
            var users = await _userManager.Users.ToListAsync();
            var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
            return userDtos;
        }
    }
}
