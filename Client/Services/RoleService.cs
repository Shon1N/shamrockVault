using ShamrockVault.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ShamrockVault.Client.Services
{
    public class RoleService : IRoleService
    {

        private readonly HttpClient httpClient;

        public RoleService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<RoleViewModel> GetRole(string roleId)
        {
            string apiRoute = $"role/one?roleId={roleId}";
            return await HttpClientJsonExtensions.GetFromJsonAsync<RoleViewModel>(httpClient, apiRoute);
        }

        public async Task<IEnumerable<RoleViewModel>> GetRoles()
        {
            string apiRoute = "role/all";
            return await HttpClientJsonExtensions.GetFromJsonAsync<RoleViewModel[]>(httpClient, apiRoute);
        }
    }
}
