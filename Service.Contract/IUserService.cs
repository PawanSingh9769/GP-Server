using Shared.DataTransferObject_DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contract
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsers(bool trackChanges);
    }
}
