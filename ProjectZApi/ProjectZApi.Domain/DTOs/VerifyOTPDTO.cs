using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectZApi.Domain.DTOs
{
    public class VerifyOTPDTO
    {
        public string Phone { get; set; }

        
        public string Code { get; set; }
    }
}
