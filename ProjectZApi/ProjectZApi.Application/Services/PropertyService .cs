using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectZApi.Domain.DTOs;
using ProjectZApi.Domain.Entities;
using ProjectZApi.Domain.Interfaces;

namespace ProjectZApi.Application.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _repository;
        public PropertyService(IPropertyRepository repository)
        {
            _repository = repository;
        }

        public async Task AddPropertyAsync(PropertyDTO propertyDTO)
        {
            var property = new Property
            {
                PropertyName = propertyDTO.PropertyName,
                PostType = propertyDTO.PostType,
                UserId = propertyDTO.UserId,
                PropertyTypeId = propertyDTO.PropertyTypeId,
                Area = propertyDTO.Area,
                City = propertyDTO.City,
                State = propertyDTO.State,
                Pincode = propertyDTO.Pincode,
                Landmark = propertyDTO.Landmark,
                ExpectedPrice = propertyDTO.ExpectedPrice,
                CarpetArea = propertyDTO.CarpetArea,

                PropertyAge = propertyDTO.PropertyAge,

                Bedrooms = propertyDTO.Bedrooms,
                Bathrooms = propertyDTO.Bathrooms,
                Balconies = propertyDTO.Balconies,

                Facing = propertyDTO.Facing,

                AvailabilityStatus = propertyDTO.AvailabilityStatus,
                Status = PropertyStatus.Pending

            };

            await _repository.AddPropertyAsync(property);
        }

        public async Task<IEnumerable<Property>> GetPropertiesByTypeAsync(int propertyTypeId)
        {
            return await _repository.GetPropertiesByTypeAsync(propertyTypeId);
        }
        public async Task DeletePropertyAsync(int propertyId)
        {
            // Add any admin-level validation or additional checks here
            await _repository.DeletePropertyByIdAsync(propertyId);
        }

        //Admin property Approval feature
        public async Task UpdatePropertyStatusAsync(int propertyId, PropertyStatus status)
        {
            await _repository.UpdatePropertyStatusAsync(propertyId, status);
        }

        public async Task<IEnumerable<PropertyDTO>> GetApprovedPropertiesAsync()
        {
            var properties = await _repository.GetApprovedPropertiesAsync();
            return properties.Select(p => new PropertyDTO
            {
                PropertyName = p.PropertyName,
                Status = p.Status
            }).ToList();
        }

        //RERA Status
        public async Task<bool> UploadReraDocumentAsync(UploadReraFileDTO uploadReraFileDTO)
        {
            // Get the full absolute path to the upload directory
            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "RERA");

            // Make sure the folder exists
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            // Clean file name and build full path
            var fileName = $"{uploadReraFileDTO.PropertyId}_{uploadReraFileDTO.File.FileName}";
            var fullFilePath = Path.Combine(uploadFolder, fileName);

            // Save the file
            using (var stream = new FileStream(fullFilePath, FileMode.Create))
            {
                await uploadReraFileDTO.File.CopyToAsync(stream);
            }

            // Save the relative path to DB (optional — cleaner for storage and portability)
            var relativePath = Path.Combine("Uploads", "RERA", fileName);

            // Update DB
            return await _repository.UpdatePropertyRegistrationAsync(uploadReraFileDTO.PropertyId, uploadReraFileDTO.RegistrationNumber, relativePath);
        }
        public async Task<bool> UpdateRERAStatusAsync(int propertyId, RERAStatus status)
        {
            return await _repository.UpdateRERAStatusAsync(propertyId, status);
        }

        // KYC Status
        public async Task<bool> UploadKYCAsync(UploadKycDTO uploadKycDTO)
        {
            // Get the full absolute path to the upload directory
            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "KYC");

            // Make sure the folder exists
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            // Clean file name and build full path
            var fileName = $"{uploadKycDTO.PropertyId}_{uploadKycDTO.File.FileName}";
            var fullFilePath = Path.Combine(uploadFolder, fileName);

            // Save the file
            using (var stream = new FileStream(fullFilePath, FileMode.Create))
            {
                await uploadKycDTO.File.CopyToAsync(stream);
            }

            // Save the relative path to DB (optional — cleaner for storage and portability)
            var relativePath = Path.Combine("Uploads", "KYC", fileName);

            // Update DB
            return await _repository.UploadKYCFileAsync(uploadKycDTO.PropertyId, relativePath);

          
        }

        public async Task<bool> VerifyKYCAsync(int propertyId, KYCStatus status)
        {
            return await _repository.UpdateKYCStatusAsync(propertyId, status);
        }
    }
}
