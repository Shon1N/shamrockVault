using Microsoft.EntityFrameworkCore;
using ShamrockVault.Client.ViewModels;
using ShamrockVault.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShamrockVault.Server.Services
{
    public class RoleService : IRoleService
    {

        public readonly ShamrockVaultDbContext _context = new ShamrockVaultDbContext();
        public async Task<RoleViewModel> GetRole(string roleId)
        {
            return await _context.AspNetRoles
                .Select(role => new RoleViewModel
                {
                    RoleId = role.Id,
                    Name = role.NormalizedName
                }).FirstOrDefaultAsync(role => role.RoleId == roleId);
        }

        public async Task<IEnumerable<RoleViewModel>> GetRoles()
        {
            return await _context.AspNetRoles.Select(role => new RoleViewModel
            {
                RoleId = role.Id,
                Name = role.NormalizedName
            }).ToListAsync();
        }
    }
}
