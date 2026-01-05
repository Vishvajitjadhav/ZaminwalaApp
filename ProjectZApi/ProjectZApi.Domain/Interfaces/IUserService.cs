using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectZApi.Domain.DTOs;
using ProjectZApi.Domain.Entities;

namespace ProjectZApi.Domain.Interfaces
{
    public interface IUserService
    {
        Task RegisterUserAsync(UserRegistrationDTO registrationDTO);

        Task<string> LoginAsync(LoginDTO loginDTO); // Perform login and return response
        Task DeleteUserAsync(int userId); // Delete user by ID for Admin

        Task<bool> ChangePasswordAsync(ChangePasswordDTO changePasswordDTO); // Update User Password

        //reset user password by otp
        Task<bool> SendOTPAsync(SendOTPDTO sendOTPDTO);
        Task<bool> ValidateOTPAsync(VerifyOTPDTO verifyOTPDTO);
        Task<bool> UserRegisterAsync(UserRegistrationDTO userDTO);
        Task<bool> ResetPasswordAsync(ResetPasswordDTO resetPasswordDTO);
    }
}
