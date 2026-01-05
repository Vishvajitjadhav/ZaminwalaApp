using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectZApi.Domain.DTOs;
using ProjectZApi.Domain.Interfaces;

namespace ProjectZApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OTPController : ControllerBase
    {
        private readonly IOTPService _otpService;
        public OTPController(IOTPService otpService)
        {
            _otpService = otpService;
             
        }

        [HttpPost("SendOTP")]
        public async Task<IActionResult> SendOTP([FromBody] SendOTPDTO sendOTPDTO)
        {
            var result = await _otpService.SendOTPAsync(sendOTPDTO);
            if (result)
                return Ok("OTP sent successfully.");

            return BadRequest("Failed to send OTP.");
        }

        [HttpPost("VerifyOTP")]
        public async Task<IActionResult> VerifyOTP([FromBody] VerifyOTPDTO verifyOTPDTO)
        {
            var result = await _otpService.ValidateOTPAsync(verifyOTPDTO);
            if (result)
                return Ok("OTP verified successfully.");

            return BadRequest("Invalid or expired OTP.");
        }


    }
}
