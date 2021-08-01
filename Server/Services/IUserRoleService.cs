using ShamrockVault.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShamrockVault.Server.Services
{
    public interface IUserRoleService
    {
        Task<IEnumerable<UserRoleViewModel>> GetUserRoles(string userId);
        Task<UserRoleViewModel> GetUserRole(UserRoleViewModel userRoleViewModel);
        Task<UserRoleViewModel> AddUserRole(UserRoleViewModel userRoleViewModel);
        UserRoleViewModel DeleteUserRole(UserRoleViewModel userRoleViewModel);
    }
}
