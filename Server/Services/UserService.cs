using Microsoft.EntityFrameworkCore;
using ShamrockVault.Client.ViewModels;
using ShamrockVault.Server.Data;
using ShamrockVault.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShamrockVault.Server.Services
{
    public class UserService : IUserService
    {
        public readonly ShamrockVaultDbContext _context = new ShamrockVaultDbContext();

        public Task<UserViewModel> AddUser(UserViewModel addUser)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteUser(string userId)
        {
            var user = await _context.AspNetUsers.FirstOrDefaultAsync(user => user.Id == userId);
            _context.AspNetUsers.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<UserViewModel> GetUser(string Id)
        {
            return await _context.AspNetUsers
                .Select(user => new UserViewModel
                {
                    UserId = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    Confirmed = user.EmailConfirmed
                }).FirstOrDefaultAsync(user => user.UserId == Id);
        }

        public async Task<IEnumerable<UserViewModel>> GetUsers()
        {
            return await _context.AspNetUsers.Select(user => new UserViewModel
            {
                UserId = user.Id,
                Email = user.Email,
                UserName = user.UserName
            }).ToListAsync();
        }

        public async Task UpdateUser(UserEditViewModel updateUser, IUserRoleService _userRoleService)
        {
            var user = await _context.AspNetUsers.FirstOrDefaultAsync(u => u.Id == updateUser.UserId);
            user.EmailConfirmed = updateUser.Confrimed;
            _context.SaveChangesAsync();

            var currentUserRoles = _userRoleService.GetUserRoles(updateUser.UserId).Result;
            var newRoles = updateUser.ListRoleViewModel.Select(role => role.RoleId);

            foreach (var role in currentUserRoles)
            {
                if (!newRoles.Contains(role.RoleId))
                {
                    var userRoleViewModel = new UserRoleViewModel
                    {
                        RoleId = role.RoleId,
                        UserId = updateUser.UserId
                    };

                    _userRoleService.DeleteUserRole(userRoleViewModel);
                }
            }

            foreach (var role in updateUser.ListRoleViewModel)
            {
                if (!currentUserRoles.Select(role => role.RoleId).Contains(role.RoleId))
                {
                    var userRoleViewModel = new UserRoleViewModel
                    {
                        RoleId = role.RoleId,
                        UserId = updateUser.UserId
                    };
                    await _userRoleService.AddUserRole(userRoleViewModel);
                }
            }
        }
    }
}
