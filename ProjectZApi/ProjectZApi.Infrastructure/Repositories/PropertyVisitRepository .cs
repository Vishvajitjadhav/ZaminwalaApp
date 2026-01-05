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
    public class PropertyVisitRepository : IPropertyVisitRepository
    {
        private readonly ProjectZDbContext _context;
        public PropertyVisitRepository(ProjectZDbContext context)
        {
            _context = context;
        }

        public async Task AddVisitAsync(int propertyId, string visitorType)
        {
            // Add a new visit record
            var propertyVisit = new PropertyVisit
            {
                PropertyId = propertyId,
                VisitorType = visitorType,
                VisitDateTime = DateTime.Now
            };

            _context.PropertyVisits.Add(propertyVisit);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetVisitCountAsync(int propertyId)
        {
            // Count the total number of visits for the property
            return await _context.PropertyVisits
                .CountAsync(v => v.PropertyId == propertyId);
        }
    }
}
