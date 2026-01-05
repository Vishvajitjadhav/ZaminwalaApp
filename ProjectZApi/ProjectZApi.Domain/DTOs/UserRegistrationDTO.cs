using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectZApi.Domain.Entities;

namespace ProjectZApi.Domain.DTOs
{
    public class UserRegistrationDTO
    {
       
        public string Name { get; set; }

       
        [EmailAddress]
        public string Email { get; set; }

        
        [Phone]
        public string Phone { get; set; }
        public string OTP { get; set; }

        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }
  
        public int RoleId { get; set; } // FK to Role
        public string RoleName { get; set; }
        

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
