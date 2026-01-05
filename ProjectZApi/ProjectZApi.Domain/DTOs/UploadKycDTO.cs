using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ProjectZApi.Domain.DTOs
{
    public class UploadKycDTO
    {
       
        public int PropertyId { get; set; } 

      
        public IFormFile File { get; set; } // Aadhaar, PAN, Passport (Photo or PDF)
    }
}
