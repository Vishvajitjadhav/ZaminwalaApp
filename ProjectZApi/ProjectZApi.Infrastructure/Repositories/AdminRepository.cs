using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectZApi.Domain.Entities;
using ProjectZApi.Domain.Interfaces;
using ProjectZApi.Infrastructure.Data;

namespace ProjectZApi.Infrastructure.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ProjectZDbContext _context;
        public AdminRepository(ProjectZDbContext context)
        {
            _context = context;
        }
        public async Task ApproveSellerAsync(int SellerStatusId)
        {
            var seller = await _context.SellerStatuses.FindAsync(SellerStatusId);
            if (seller != null)
            {
                seller.Status = "Approved";
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SellerStatus>> GetPendingSellerAsync()
        {
            return await _context.SellerStatuses.Where(s => s.Status == "Pending").ToListAsync();
        }

        public async Task RejectSellerAsync(int SellerStatusId)
        {
            var seller = await _context.SellerStatuses.FindAsync(SellerStatusId);
            if (seller != null)
            {
                seller.Status = "Rejected";
                await _context.SaveChangesAsync();
            }
        }

        //Admin Login
        public User ValidateAdmin(string username, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Name == username && u.Password == password && u.RoleId == 1); // RoleId 1 for Admin
        }
    }
}
