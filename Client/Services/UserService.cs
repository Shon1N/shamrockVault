using ShamrockVault.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;

namespace ShamrockVault.Client.Services
{
    public class UserService : IUserService
    {

        private readonly HttpClient httpClient;

        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<UserViewModel> AddUser(UserViewModel updatedUser)
        {
            //Just let users register
            throw new NotImplementedException();
        }

        public async Task DeleteUser(string userId)
        {
            string apiRoute = $"user/delete";
            await HttpClientJsonExtensions.PostAsJsonAsync(httpClient, apiRoute, userId);
        }

        public async Task<UserViewModel> GetUser(string userId)
        {
            string apiRoute = $"user/search?userId={userId}";
            return await HttpClientJsonExtensions.GetFromJsonAsync<UserViewModel>(httpClient, apiRoute);
        }

        public async Task<IEnumerable<UserViewModel>> GetUsers()
        {
            string apiRoute = $"user/all";
            return await HttpClientJsonExtensions.GetFromJsonAsync<UserViewModel[]>(httpClient, apiRoute);
        }

        public async Task UpdateUser(UserEditViewModel updateUser)
        {
            string apiRoute = $"user/update";
            await HttpClientJsonExtensions.PostAsJsonAsync(httpClient, apiRoute, updateUser);
        }
    }
}
