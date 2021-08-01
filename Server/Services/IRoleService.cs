using ShamrockVault.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShamrockVault.Server.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleViewModel>> GetRoles();
        Task<RoleViewModel> GetRole(string roleId);
    }
}
