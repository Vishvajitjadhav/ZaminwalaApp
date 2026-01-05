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
    public class ReviewRepository : IReviewRepository
    {
        private readonly ProjectZDbContext _context;

        public ReviewRepository(ProjectZDbContext context)
        {
            _context = context;
        }

        public async Task AddReviewAsync(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Review>> GetReviewsByPropertyIdAsync(int propertyId)
        {
            return await _context.Reviews
                .Where(r => r.PropertyId == propertyId)
                .Include(r => r.User) // Optional: Include user details
                .ToListAsync();
        }
    }
}
