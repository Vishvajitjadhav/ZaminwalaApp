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
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _services;
        public AdminController(IAdminService services)
        {
            _services = services;
        }

        //Admin to approve Seller feature if needed-- need to change code
        [HttpGet("PendingSellers")]
        public async Task<ActionResult<IEnumerable<SellerStatus>>> GetPendingSellers()
        {
            var seller = await _services.GetPendingSellerAsync();
            return Ok(seller);
        }

        [HttpPut("Approve/{SellerStatusId}")]
        public async Task<ActionResult> ApproveSeller(int SellerStatusId)
        {
            await _services.ApproveSellerAsync(SellerStatusId);
            return NoContent();
        }

        [HttpPut("Reject/{SellerStatusId}")]
        public async Task<ActionResult> RejectSeller(int SellerStatusId)
        {
            await _services.RejectSellerAsync(SellerStatusId);
            return NoContent();
        }

        //----------------------------------------------------------------------------

        //Admin Login
        [HttpPost("Login")]
        public ActionResult<User> AdminLogin([FromBody] LoginDTO loginDTO)
        {
            try
            {
                var admin = _services.ValidateAdmin(loginDTO.Name, loginDTO.Password);
                if (admin == null)
                {
                    return Unauthorized("Invalid credentials.");
                }
                return Ok(new
                {
                    Message = "Login successful!",
                    AdminDetails = admin
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("Dashboard")]
        public ActionResult<string> AdminDashboard()
        {
            return Ok("Welcome to the Admin Dashboard!");
        }
    }
}
