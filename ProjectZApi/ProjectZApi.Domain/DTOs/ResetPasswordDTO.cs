using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectZApi.Domain.DTOs
{
    public class ResetPasswordDTO
    {
        
        [Phone]
        public string Phone { get; set; }

        public string OTP { get; set; } // Verify OTP before allowing password reset

   
        public string NewPassword { get; set; }
    }
}
