using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectZApi.Domain.DTOs
{
    public class EnquiryDTO
    {
        public int PropertyId { get; set; } 
        public string UserType { get; set; } // Individual, Dealer, Investment, Self-use
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Comment { get; set; }
    }
}
