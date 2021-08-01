using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShamrockVault.Client.ViewModels
{
    public class UserEditViewModel
    {
        public string UserId { get; set; }
        public List<UserRoleViewModel> ListRoleViewModel { get; set; } = new List<UserRoleViewModel>();
        public bool Confrimed { get; set; }

    }
}
