using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShamrockVault.Client.ViewModels;
using ShamrockVault.Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShamrockVault.Server.Controllers
{
    public class UserRoleController : Controller
    {
        public readonly IUserRoleService _userRoleService;
        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [Route("api/[controller]/one")]
        [HttpGet]
        public async Task<UserRoleViewModel> GetUserRole(UserRoleViewModel UserRoleViewModel)
        {
            return await _userRoleService.GetUserRole(UserRoleViewModel);
        }

        [Route("api/[controller]/all")]
        [HttpGet]
        public async Task<IEnumerable<UserRoleViewModel>> GetUserRoles(string userId)
        {
            return await _userRoleService.GetUserRoles(userId);
        }

    }
}
