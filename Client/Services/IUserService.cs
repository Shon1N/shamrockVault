using ShamrockVault.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShamrockVault.Client.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetUsers();
        Task<UserViewModel> GetUser(string Id);
        Task UpdateUser(UserEditViewModel updateUser);
        Task<UserViewModel> AddUser(UserViewModel addUser);
        Task DeleteUser(string userId);
    }
}
