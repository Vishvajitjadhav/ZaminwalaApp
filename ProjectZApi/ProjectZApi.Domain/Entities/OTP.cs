using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectZApi.Domain.Entities
{
    public class OTP
    {
        [Key]
        public int Id { get; set; }
        
        public string Phone { get; set; } // Phone number to verify
        public string Code { get; set; } // OTP code

        public DateTime Expiration { get; set; } // OTP expiry time

        public bool IsUsed { get; set; } = false;
    }
}
