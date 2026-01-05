using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectZApi.Domain.DTOs;
using ProjectZApi.Domain.Entities;
using ProjectZApi.Domain.Interfaces;
using ProjectZApi.Infrastructure.Data;

namespace ProjectZApi.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ProjectZDbContext _context;
        private readonly IOTPRepository _otpRepository;

        public UserRepository(ProjectZDbContext context, IOTPRepository otpRepository)
        {
            _context = context;
            _otpRepository = otpRepository;
        }

        public async Task<bool> IsEmailExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> IsPhoneExistsAsync(string phone)
        {
            return await _context.Users.AnyAsync(u => u.Phone == phone);
        }

        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Name == username); 
        }

        //For Admin to delete user
        public async Task DeleteUserByIdAsync(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user != null)
            {
                _context.Users.Remove(user); // Delete the user
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("User not found.");
            }
        }

        //Update User Password
        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<bool> UpdatePasswordAsync(int userId, string newPassword)
        {
            var user = await GetUserByIdAsync(userId);
            if (user == null)
                return false;

            user.Password = newPassword; // Plain-text password
            await _context.SaveChangesAsync();
            return true;
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
        public async Task<bool> UserRegisterAsync(UserRegistrationDTO userDTO)
        {
            bool isOTPValid = await _otpRepository.VerifyOTPAsync(userDTO.Phone, userDTO.OTP);
            if (!isOTPValid)
                throw new Exception("Invalid or expired OTP");

            var newUser = new User
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                Phone = userDTO.Phone,
                Password = userDTO.Password,
                RoleId = userDTO.RoleId,
                CreatedAt = userDTO.CreatedAt
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> ResetPasswordAsync(ResetPasswordDTO resetPasswordDTO)
        {
            bool isOTPValid = await _otpRepository.VerifyOTPAsync(resetPasswordDTO.Phone, resetPasswordDTO.OTP);
            if (!isOTPValid)
                throw new Exception("Invalid OTP");

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Phone == resetPasswordDTO.Phone);
            if (user == null)
                return false;

            user.Password = resetPasswordDTO.NewPassword;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
