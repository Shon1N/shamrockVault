using Microsoft.EntityFrameworkCore;
using ShamrockVault.Client.ViewModels;
using ShamrockVault.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShamrockVault.Server.Services
{
    public class UserRoleService : IUserRoleService
    {

        public readonly ShamrockVaultDbContext _context = new ShamrockVaultDbContext();

        public async Task<UserRoleViewModel> AddUserRole(UserRoleViewModel userRoleViewModel)
        {
            _context.AspNetUserRoles.Add(new AspNetUserRole
            {
                RoleId = userRoleViewModel.RoleId,
                UserId = userRoleViewModel.UserId
            });
            await _context.SaveChangesAsync();
            return userRoleViewModel;
        }

        public UserRoleViewModel DeleteUserRole(UserRoleViewModel userRoleViewModel)
        {
            var userRole = _context.AspNetUserRoles.FirstOrDefault(userrole => userrole.UserId == userRoleViewModel.UserId && userrole.RoleId == userRoleViewModel.RoleId);
            var removedRole = new UserRoleViewModel
            {
                RoleId = userRole.RoleId,
                UserId = userRole.UserId
            };

            _context.AspNetUserRoles.Remove(userRole);
            return removedRole;
        }

        public async Task<UserRoleViewModel> GetUserRole(UserRoleViewModel userRoleViewModel)
        {
            return await _context.AspNetUserRoles
                .Select(userrole => new UserRoleViewModel
                {
                    RoleId = userrole.RoleId,
                    UserId = userrole.UserId
                }).FirstOrDefaultAsync(userrole => userrole.RoleId == userRoleViewModel.RoleId && userrole.UserId == userRoleViewModel.UserId);
        }

        public async Task<IEnumerable<UserRoleViewModel>> GetUserRoles(string userId)
        {
            return await _context.AspNetUserRoles.Select(userrole => new UserRoleViewModel
            {
                RoleId = userrole.RoleId,
                UserId = userrole.UserId
            }).Where(userrole => userrole.UserId == userId).ToListAsync();
        }
    }
}
