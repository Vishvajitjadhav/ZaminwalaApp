using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ProjectZApi.Domain.DTOs
{
    public class UploadReraFileDTO
    {
       
        public int PropertyId { get; set; } // Property ID

        
        public string RegistrationNumber { get; set; } // 7/12 document number

        
        public IFormFile File { get; set; } // Uploaded RERA file
    }
}
