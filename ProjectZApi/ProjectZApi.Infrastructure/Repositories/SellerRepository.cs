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
    public class SellerRepository : ISellerRepository
    {
        private readonly ProjectZDbContext _context;
        public SellerRepository(ProjectZDbContext context)
        {
            _context = context;
        }
        public async Task<User> ValidateSellerAsync(string email, string password)
        {
            // RoleId 2 = Seller
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password && u.RoleId == 2);
           
        }



    }
}
