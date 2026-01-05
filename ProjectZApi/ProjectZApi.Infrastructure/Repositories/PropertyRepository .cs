using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectZApi.Domain.DTOs;
using ProjectZApi.Domain.Entities;
using ProjectZApi.Domain.Interfaces;
using ProjectZApi.Infrastructure.Data;

namespace ProjectZApi.Infrastructure.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly ProjectZDbContext _context;
        public PropertyRepository(ProjectZDbContext context)
        {
            _context = context;
        }
        public async Task AddPropertyAsync(Property property)
        {
            property.RStatus = RERAStatus.NotVerified;
            property.Status = PropertyStatus.Pending;
            _context.Properties.Add(property);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Property>> GetPropertiesByTypeAsync(int propertyTypeId)
        {
            return await _context.Properties
            .Where(p => p.PropertyTypeId == propertyTypeId)
            .Include(p => p.PropertyType) 
            .ToListAsync();
        }

        //Delte Properties by Admin
        public async Task DeletePropertyByIdAsync(int propertyId)
        {
            var property = await _context.Properties.FirstOrDefaultAsync(p => p.Id == propertyId);

            if (property != null)
            {
                _context.Properties.Remove(property); // Remove the property
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Property not found.");
            }
        }

        //Admin property approval feature
        public async Task UpdatePropertyStatusAsync(int propertyId, PropertyStatus status)
        {
            var property = await _context.Properties.FindAsync(propertyId);
            if (property == null)
            {
                throw new Exception("Property not found.");
            }

            property.Status = status;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Property>> GetApprovedPropertiesAsync()
        {
            return await _context.Properties
                .Where(p => p.Status == PropertyStatus.Approved) // Only fetch approved properties
                .ToListAsync();
        }

        //RERA Status
        public async Task<bool> UpdatePropertyRegistrationAsync(int propertyId, string registrationNumber, string filePath)
        {
            var property = await _context.Properties.FindAsync(propertyId);
            if (property == null)
                return false;

            property.RegistrationNumber = registrationNumber;
            property.UploadReraFilePath = filePath;
            property.RStatus = RERAStatus.NotVerified; // Move status to pending

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateRERAStatusAsync(int propertyId, RERAStatus status)
        {
            var property = await _context.Properties.FindAsync(propertyId);
            if (property == null)
                return false;

            property.RStatus = status;
            await _context.SaveChangesAsync();
            return true;
        }

        // KYC Status
        public async Task<bool> UploadKYCFileAsync(int propertyId, string filePath)
        {
            var property = await _context.Properties.FindAsync(propertyId);
            if (property == null)
                return false;

            property.KYCFilePath = filePath;
            property.KYCStatus = KYCStatus.PendingVerification; // Move status to pending

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateKYCStatusAsync(int propertyId, KYCStatus status)
        {
            var property = await _context.Properties.FindAsync(propertyId);
            if (property == null)
                return false;

            property.KYCStatus = status; // Update verification status
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
