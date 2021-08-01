using ShamrockVault.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ShamrockVault.Client.Services
{
    public class UserRoleService : IUserRoleService
    {

        private readonly HttpClient httpClient;

        public UserRoleService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<UserRoleViewModel> GetUserRole(string userRoleId)
        {
            string apiRoute = $"userrole/one?userRoleId{userRoleId}";
            return await HttpClientJsonExtensions.GetFromJsonAsync<UserRoleViewModel>(httpClient, apiRoute);
        }

        public async Task<IEnumerable<UserRoleViewModel>> GetUserRoles(string userId)
        {
            string apiRoute = $"userrole/all?userId={userId}";
            return await HttpClientJsonExtensions.GetFromJsonAsync<UserRoleViewModel[]>(httpClient, apiRoute);
        }
    }
}
