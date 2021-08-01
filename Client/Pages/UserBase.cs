using Microsoft.AspNetCore.Components;
using ShamrockVault.Client.Services;
using ShamrockVault.Client.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShamrockVault.Client.Pages
{
    public abstract class UserBase : ComponentBase
    {
        [Inject]
        public IUserService UserService { get; set; }
        public IEnumerable<UserViewModel> Users { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Users = (await UserService.GetUsers()).ToList();
        }

        public async Task DeleteUser(string userId)
        {
            await UserService.DeleteUser(userId);
        }
    }
}
