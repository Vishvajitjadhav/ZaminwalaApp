using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ProjectZApi.Domain.DTOs;
using ProjectZApi.Domain.Entities;

namespace ProjectZApi.Domain.Interfaces
{
    public interface IPropertyService
    {
        Task AddPropertyAsync(PropertyDTO propertyDTO);
        Task<IEnumerable<Property>> GetPropertiesByTypeAsync(int propertyTypeId);
        Task DeletePropertyAsync(int propertyId); // Delete property by ID

        //Admin Approval Property
        Task UpdatePropertyStatusAsync(int propertyId, PropertyStatus status); // Admin updates status
        Task<IEnumerable<PropertyDTO>> GetApprovedPropertiesAsync();

        //RERA Status
        Task<bool> UploadReraDocumentAsync(UploadReraFileDTO uploadReraFileDTO);
        Task<bool> UpdateRERAStatusAsync(int propertyId, RERAStatus status);

        // KYC Status
        Task<bool> UploadKYCAsync(UploadKycDTO uploadKycDTO);
        Task<bool> VerifyKYCAsync(int propertyId, KYCStatus status);
    }
}
