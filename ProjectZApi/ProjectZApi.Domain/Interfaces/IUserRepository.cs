using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectZApi.Domain.DTOs;
using ProjectZApi.Domain.Entities;

namespace ProjectZApi.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> IsEmailExistsAsync(string email); 
        Task<bool> IsPhoneExistsAsync(string phone); 
        Task AddUserAsync(User user);

        Task<User> GetUserByUsernameAsync(string username); // User Login

        Task DeleteUserByIdAsync(int userId); // "For Admin"

        //Update User Password
        Task<User> GetUserByIdAsync(int userId); 
        Task<bool> UpdatePasswordAsync(int userId, string newPassword);

        //Reset User Password by otp
        Task<bool> UserRegisterAsync(UserRegistrationDTO userDTO);
        Task<bool> ResetPasswordAsync(ResetPasswordDTO resetPasswordDTO);
    }
}
