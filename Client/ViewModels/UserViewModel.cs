using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShamrockVault.Client.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {

        }

        public string UserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public bool Confirmed { get; set; }
    }
}
