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
    public class EnquiryRepository : IEnquiryRepository
    {
        private readonly ProjectZDbContext _context;

        public EnquiryRepository(ProjectZDbContext context)
        {
            _context = context;
        }

        public async Task AddEnquiryAsync(Enquiry enquiry)
        {
            _context.Enquiry.Add(enquiry);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Enquiry>> GetEnquiriesByPropertyAsync(int propertyId)
        {
            return await _context.Enquiry
                .Where(e => e.PropertyId == propertyId)
                .ToListAsync();
        }
    }
}
