using ShamrockVault.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShamrockVault.Client.Services
{
    public interface IUserRoleService
    {
        Task<IEnumerable<UserRoleViewModel>> GetUserRoles(string userId);
        Task<UserRoleViewModel> GetUserRole(string userRoleId);
    }
}
