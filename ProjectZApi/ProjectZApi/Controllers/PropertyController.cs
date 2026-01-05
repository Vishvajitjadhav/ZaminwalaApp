using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectZApi.Application.Services;
using ProjectZApi.Domain.DTOs;
using ProjectZApi.Domain.Entities;
using ProjectZApi.Domain.Interfaces;

namespace ProjectZApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _services;
        private readonly IReviewService _reviewService;
        private readonly IPropertyVisitService _visitService;
        public PropertyController(IPropertyService services, IReviewService reviewService, IPropertyVisitService visitService)
        {
            _services = services;
            _reviewService = reviewService;
            _visitService = visitService;
        }

        [HttpPost("Add")]
        //[Authorize(Roles = "Admin, Seller")]
        public async Task<IActionResult> AddProperty([FromBody] PropertyDTO propertyDTO)
        {
            if (propertyDTO == null)
            {
                return BadRequest("The propertyDTO field is required.");
            }

            await _services.AddPropertyAsync(propertyDTO);
            return Ok("Property added successfully!");
        }

        [HttpGet("Type/{propertyTypeId}")]
        public async Task<ActionResult<IEnumerable<PropertyDTO>>> GetPropertiesByType(int propertyTypeId)
        {
            var properties = await _services.GetPropertiesByTypeAsync(propertyTypeId);

            var filteredProperties = properties.Select(p => new PropertyDTO
            {
                PropertyName = p.PropertyName,
                PostType = p.PostType,
                Area = p.Area,
                City = p.City,
                State = p.State,
                Pincode = p.Pincode,
                ExpectedPrice = (int)p.ExpectedPrice,
                CarpetArea = (int)p.CarpetArea,
            
                Bedrooms = (int)p.Bedrooms,
                Bathrooms = (int)p.Bathrooms,
                Facing = p.Facing,
               // PropertyTypeId = p.PropertyTypeId
            });

            return Ok(filteredProperties);
        }

        //Reviews
        [HttpPost("AddReview")]
        public async Task<IActionResult> AddReview([FromBody] ReviewDTO reviewDTO)
        {
            await _reviewService.AddReviewAsync(reviewDTO);
            return Ok("Review added successfully!");
        }

        [HttpGet("{propertyId}/Reviews")]
        public async Task<IActionResult> GetReviewsByPropertyId(int propertyId)
        {
            var reviews = await _reviewService.GetReviewsByPropertyIdAsync(propertyId);
            return Ok(reviews);
        }

        //Add Visitor Count for Properties
        [HttpPost("{propertyId}/AddVisit")]
        public async Task<IActionResult> AddVisit(int propertyId, [FromQuery] string visitorType)
        {
            // Record a visit
            await _visitService.AddVisitAsync(propertyId, visitorType);
            return Ok("Visit recorded successfully!");
        }

        [HttpGet("{propertyId}/VisitCount")]
        public async Task<IActionResult> GetVisitCount(int propertyId)
        {
            // Get the total visit count
            var count = await _visitService.GetVisitCountAsync(propertyId);
            return Ok(new { PropertyId = propertyId, VisitCount = count });
        }

        //only Admin Can
        [HttpDelete("Delete/{propertyId}")]
        //[Authorize(Roles = "Admin")] 
        public async Task<IActionResult> DeleteProperty(int propertyId)
        {
            await _services.DeletePropertyAsync(propertyId);
            return Ok($"Property with ID {propertyId} has been deleted successfully.");
        }


        //Admin property Approval feature
        [HttpPut("UpdateStatus/{propertyId}")]
        //[Authorize(Roles = "Admin")] // Restrict this API to admins
        public async Task<IActionResult> UpdatePropertyStatus(int propertyId, [FromQuery] PropertyStatus status)
        {
            await _services.UpdatePropertyStatusAsync(propertyId, status);
            return Ok($"Property status updated to {status}.");
        }

        [HttpGet("Approved")]
        public async Task<IActionResult> GetApprovedProperties()
        {
            var properties = await _services.GetApprovedPropertiesAsync();
            return Ok(properties);
        }

        //RERA STATUS
        [HttpPost("UploadRERADocument")]
        public async Task<IActionResult> UploadReraDocument([FromForm] UploadReraFileDTO uploadReraFileDTO)
        {
            var result = await _services.UploadReraDocumentAsync(uploadReraFileDTO);
            if (result)
                return Ok("RERA details uploaded successfully. Waiting for admin approval.");

            return BadRequest("Failed to upload RERA details.");
        }
        //Admin verifies the RERA Status
        [HttpPut("VerifyRERA/{propertyId}")]
        //[Authorize(Roles = "Admin")] // Only admins can verify properties
        public async Task<IActionResult> VerifyRERA(int propertyId, [FromQuery] RERAStatus status)
        {
            var result = await _services.UpdateRERAStatusAsync(propertyId, status);
            if (result)
                return Ok($"Property verification updated to {status}.");

            return BadRequest("Failed to update RERA status.");
        }

        // KYC Status
        [HttpPost("UploadKYC")]
        public async Task<IActionResult> UploadKYC([FromForm] UploadKycDTO uploadKycDTO)
        {
            var result = await _services.UploadKYCAsync(uploadKycDTO);
            if (result)
                return Ok("KYC documents uploaded successfully. Waiting for admin approval.");

            return BadRequest("Failed to upload KYC documents.");
        }

        [HttpPut("VerifyKYC/{propertyId}")]
        //[Authorize(Roles = "Admin")] // Only admins can verify KYC
        public async Task<IActionResult> VerifyKYC(int propertyId, [FromQuery] KYCStatus status)
        {
            var result = await _services.VerifyKYCAsync(propertyId, status);
            if (result)
                return Ok($"Property KYC verification updated to {status}.");

            return BadRequest("Failed to update KYC status.");
        }
    }
}
