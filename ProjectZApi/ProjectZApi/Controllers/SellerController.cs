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
    public class SellerController : ControllerBase
    {
        private readonly ISellerServices _service;

        public SellerController(ISellerServices service)
        {
            _service = service;
        }

        [HttpPost("SellerLogin")]
        public async Task<ActionResult<User>> SellerLogin([FromBody] SellerLoginDTO sellerloginDTO)
        {
            var seller = await _service.ValidateSellerAsync(sellerloginDTO.Email, sellerloginDTO.Password);
            if (seller == null)
            {
                return Unauthorized("Invalid credentials or not a seller.");
            }

           
            return Ok(new
            {
                Message = "Login successful!",
                SellerDetails = seller
            });
        }
    }

    
}
