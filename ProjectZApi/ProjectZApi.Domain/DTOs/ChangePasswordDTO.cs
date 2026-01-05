using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectZApi.Domain.DTOs
{
    public class ChangePasswordDTO
    {
        
        public int UserId { get; set; } 
        
        public string CurrentPassword { get; set; } 
        public string NewPassword { get; set; } // New password

        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }
    }
}
