using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectZApi.Domain.DTOs;
using ProjectZApi.Domain.Entities;

namespace ProjectZApi.Domain.Interfaces
{
    public interface IPropertyRepository
    {
        Task AddPropertyAsync(Property property);
        Task<IEnumerable<Property>> GetPropertiesByTypeAsync(int propertyTypeId);

        Task DeletePropertyByIdAsync(int propertyId); // Delete a property by ID

        // Admin Property Approval Feature
        Task UpdatePropertyStatusAsync(int propertyId, PropertyStatus status); // Admin updates status
        Task<IEnumerable<Property>> GetApprovedPropertiesAsync();

        //RERA Status
        Task<bool> UpdateRERAStatusAsync(int propertyId, RERAStatus status); // Admin verification
        Task<bool> UpdatePropertyRegistrationAsync(int propertyId, string registrationNumber, string filePath);

        //KYC Status
        Task<bool> UploadKYCFileAsync(int propertyId, string filePath);
        Task<bool> UpdateKYCStatusAsync(int propertyId, KYCStatus status);
    }
}
