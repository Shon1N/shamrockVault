using Microsoft.AspNetCore.Mvc;
using ShamrockVault.Server.Services;
using ShamrockVault.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ShamrockVault.Server.Controllers
{

    [ApiController]
    //[Authorize]
    public class UserController : Controller
    {

        public readonly IUserService _userService;
        public readonly IUserRoleService _userRoleService;
        public UserController(IUserService userService, IUserRoleService userRoleService)
        {
            _userService = userService;
            _userRoleService = userRoleService;
        }

        [Route("api/[controller]/all")]
        [HttpGet]
        public async Task<IEnumerable<UserViewModel>> GetUsers()
        {
            return await _userService.GetUsers();
        }

        [Route("api/[controller]/search")]
        [HttpGet]
        public async Task<UserViewModel> GetUser(string userId)
        {
            return await _userService.GetUser(userId);
        }

        [Route("api/[controller]/delete")]
        [HttpPost]
        public async Task DeleteUser(string userId)
        {
            await _userService.DeleteUser(userId);
        }

        [Route("api/[controller]/update")]
        [HttpPost]
        public async Task UpdateUser(UserEditViewModel updateUser)
        {
            await _userService.UpdateUser(updateUser, _userRoleService);
        }
    }
}
