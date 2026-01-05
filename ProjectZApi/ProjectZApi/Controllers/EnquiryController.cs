using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectZApi.Domain.DTOs;
using ProjectZApi.Domain.Interfaces;

namespace ProjectZApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnquiryController : ControllerBase
    {
        private readonly IEnquiryService _enquiryService;

        public EnquiryController(IEnquiryService enquiryService)
        {
            _enquiryService = enquiryService;
        }

        [HttpPost("Submit")]
        public async Task<IActionResult> SubmitEnquiry([FromBody] EnquiryDTO enquiryDTO)
        {
            await _enquiryService.SubmitEnquiryAsync(enquiryDTO);
            return Ok("Enquiry submitted successfully.");
        }

        [HttpGet("Property/{propertyId}")]
        public async Task<IActionResult> GetEnquiries(int propertyId)
        {
            var enquiries = await _enquiryService.GetEnquiriesByPropertyAsync(propertyId);
            return Ok(enquiries);
        }
    }
}
