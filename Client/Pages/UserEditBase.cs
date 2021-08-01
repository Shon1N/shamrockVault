using Microsoft.AspNetCore.Components;
using ShamrockVault.Client.Services;
using ShamrockVault.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShamrockVault.Client.Pages
{
    public class UserEditBasee : ComponentBase
    {

        public UserViewModel User { get; set; } = new UserViewModel();
        public List<UserRoleViewModel> UserRoles { get; set; } = new List<UserRoleViewModel>();
        public List<RoleViewModel> Roles { get; set; } = new List<RoleViewModel>();
        public List<RoleViewModel> RolesOfUser { get; set; } = new List<RoleViewModel>();
        public UserEditViewModel UserEditViewModel { get; set; } = new UserEditViewModel();

        [Parameter]
        public string userId { get; set; }

        [Inject]
        public IUserService UserService { get; set; }

        [Inject]
        public IRoleService RoleService { get; set; }

        [Inject]
        public IUserRoleService UserRoleService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            User = (await UserService.GetUser(userId));
            Roles = (await RoleService.GetRoles()).ToList();
            UserRoles = (await UserRoleService.GetUserRoles(userId)).ToList();
            var rolesOfUser = UserRoles.Select(r => r.RoleId).ToList();

            foreach (var role in Roles)
            {
                RolesOfUser.Add(new RoleViewModel
                {
                    RoleId = role.RoleId,
                    Name = role.Name,
                    IsSelected = rolesOfUser.Contains(role.RoleId)

                });
            }

        }

        public async Task DeleteUser(string userId)
        {

        }

        protected async Task HasValidSubmit()
        {
            UserEditViewModel.UserId = userId;
            UserEditViewModel.Confrimed = User.Confirmed;
            foreach (var roles in RolesOfUser)
            {
                if (roles.IsSelected)
                {
                    UserEditViewModel.ListRoleViewModel.Add(new UserRoleViewModel
                    {
                        UserId = userId,
                        RoleId = roles.RoleId
                    });
                }

                await UserService.UpdateUser(UserEditViewModel);
            }
        }

    }
}
