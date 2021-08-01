using ShamrockVault.Client.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShamrockVault.Server.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetUsers();
        Task<UserViewModel> GetUser(string Id);
        Task UpdateUser(UserEditViewModel updateUser, IUserRoleService _userRoleService);
        Task<UserViewModel> AddUser(UserViewModel addUser);
        Task DeleteUser(string userId);
    }
}
