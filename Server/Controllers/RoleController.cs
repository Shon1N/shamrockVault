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
    public class RoleController : Controller
    {
        public readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [Route("api/[controller]/one")]
        [HttpGet]
        public async Task<RoleViewModel> GetUserRole(string roleId)
        {
            return await _roleService.GetRole(roleId);
        }

        [Route("api/[controller]/all")]
        [HttpGet]
        public async Task<IEnumerable<RoleViewModel>> GetUserRoles()
        {
            return await _roleService.GetRoles();
        }
    }
}
