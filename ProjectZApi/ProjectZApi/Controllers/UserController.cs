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
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IOTPRepository _otpRepository;

        public UserController(IUserService service)
        {
            _service = service;
        }

        // User Registration
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDTO registrationDTO)
        {
            await _service.RegisterUserAsync(registrationDTO);
            return Ok("User registered successfully!");
        }

        // User Login
        [HttpPost("UserLogin")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var response = await _service.LoginAsync(loginDTO);
            return Ok(response);
        }

        //For Admin to delete user
        [HttpDelete("Delete/{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            await _service.DeleteUserAsync(userId);
            return Ok($"User with ID {userId} has been deleted successfully.");
        }

        //Update user Password
        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO changePasswordDTO)
        {
            var result = await _service.ChangePasswordAsync(changePasswordDTO);
            if (result)
                return Ok("Password changed successfully.");

            return BadRequest("Failed to change password.");
        }

        //Reset user password by otp
        [HttpPost("SendOTP")]
        public async Task<IActionResult> SendOTP([FromBody] SendOTPDTO sendOTPDTO)
        {
            var result = await _service.SendOTPAsync(sendOTPDTO);
            if (result)
                return Ok("OTP sent successfully.");

            return BadRequest("Failed to send OTP.");
        }

        [HttpPost("VerifyOTP")]
        public async Task<IActionResult> VerifyOTP([FromBody] VerifyOTPDTO verifyOTPDTO)
        {
            var result = await _service.ValidateOTPAsync(verifyOTPDTO);
            if (result)
                return Ok("OTP verified successfully.");

            return BadRequest("Invalid or expired OTP.");
        }

        [HttpPost("UserRegister")]
        public async Task<IActionResult> UserRegister([FromBody] UserRegistrationDTO userDTO)
        {
            var result = await _service.UserRegisterAsync(userDTO);
            return result ? Ok("User registered successfully.") : BadRequest("Invalid OTP or registration failed.");
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO resetPasswordDTO)
        {
            var result = await _service.ResetPasswordAsync(resetPasswordDTO);
            return result ? Ok("Password reset successfully.") : BadRequest("Invalid OTP or password reset failed.");
        }

    }
}
