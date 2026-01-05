using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ProjectZApi.Domain.DTOs;
using ProjectZApi.Domain.Entities;
using ProjectZApi.Domain.Interfaces;

namespace ProjectZApi.Application.Services
{
    public class UserService : IUserService
    {
        //Registration
        private readonly IUserRepository _repository;
        private readonly IOTPRepository _otpRepository;

        public UserService(IUserRepository repository, IOTPRepository otpRepository)
        {
            _repository = repository;
            _otpRepository = otpRepository;
        }

        public async Task RegisterUserAsync(UserRegistrationDTO registrationDTO)
        {
            // Check if email or phone already exists
            if (await _repository.IsEmailExistsAsync(registrationDTO.Email))
            {
                throw new Exception("Email already exists.");
            }

            if (await _repository.IsPhoneExistsAsync(registrationDTO.Phone))
            {
                throw new Exception("Phone already exists.");
            }

            // Hash the password
            //string hashedPassword = HashPassword(registrationDTO.Password);

            // Map DTO to User entity
            var user = new User
            {
                Name = registrationDTO.Name,
                Email = registrationDTO.Email,
                Phone = registrationDTO.Phone,
                Password = registrationDTO.Password,//hashedPassword,
                RoleId = registrationDTO.RoleId,
                CreatedAt = registrationDTO.CreatedAt
            };

            // Save the user
            await _repository.AddUserAsync(user);
        }

        //private string HashPassword(string password)
        //{
        //    using (SHA256 sha256 = SHA256.Create())
        //    {
        //        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        //        return Convert.ToBase64String(bytes);
        //    }
        //}

        //if you dont want hashpassword remove hashpassword from this code then you can see you exact password in database
        //we use hashpassword so hacker can't hack your system

        public async Task<string> LoginAsync(LoginDTO loginDTO)
        {
            
            var user = await _repository.GetUserByUsernameAsync(loginDTO.Name);

            if (user == null)
            {
                throw new Exception("Invalid username "); 
            }

            // Validate the password
            if (user.Password != loginDTO.Password) 
            {
                throw new Exception("Invalid password."); 
            }

            return $"Welcome back, {user.Name}!";
        }

        //For Admin to delete user
        public async Task DeleteUserAsync(int userId)
        {
            // Add any validation checks here (e.g., ensure user is not admin)
            await _repository.DeleteUserByIdAsync(userId);
        }

        //Update User Password
        public async Task<bool> ChangePasswordAsync(ChangePasswordDTO changePasswordDTO)
        {
            var user = await _repository.GetUserByIdAsync(changePasswordDTO.UserId);
            if (user == null)
                throw new Exception("User not found.");

            if (user.Password != changePasswordDTO.CurrentPassword)
                throw new Exception("Current password is incorrect.");

            if (!await _repository.UpdatePasswordAsync(changePasswordDTO.UserId, changePasswordDTO.NewPassword))
                throw new Exception("Password update failed.");

            return true; // Password successfully updated
        }

        /*
        // Hashing function for future use
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
        */

        //Reset user password by otp
        public async Task<bool> SendOTPAsync(SendOTPDTO sendOTPDTO)
        {
            return await _otpRepository.GenerateOTPAsync(sendOTPDTO.Phone);
        }

        public async Task<bool> ValidateOTPAsync(VerifyOTPDTO verifyOTPDTO)
        {
            return await _otpRepository.VerifyOTPAsync(verifyOTPDTO.Phone, verifyOTPDTO.Code);
        }

        public async Task<bool> UserRegisterAsync(UserRegistrationDTO userDTO)
        {
            return await _repository.UserRegisterAsync(userDTO);
        }

        public async Task<bool> ResetPasswordAsync(ResetPasswordDTO resetPasswordDTO)
        {
            return await _repository.ResetPasswordAsync(resetPasswordDTO);
        }
    }
}
