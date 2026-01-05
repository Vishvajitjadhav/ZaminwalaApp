using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectZApi.Domain.DTOs;
using ProjectZApi.Domain.Interfaces;

namespace ProjectZApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllLocations()
        {
            var locations = await _locationService.GetAllLocationsAsync();
            return Ok(locations);
        }

        [HttpPost("Add")]
        [Authorize(Roles = "Admin")] // Restrict this to admin users
        public async Task<IActionResult> AddLocation([FromBody] LocationDTO locationDTO)
        {
            await _locationService.AddLocationAsync(locationDTO);
            return Ok($"Location '{locationDTO.City}' added successfully.");
        }
    }
}
