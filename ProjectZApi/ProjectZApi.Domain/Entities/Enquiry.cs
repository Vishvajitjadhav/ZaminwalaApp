using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectZApi.Domain.Entities
{
    public class Enquiry
    {
        [Key]
        public int Id { get; set; } 
        public int PropertyId { get; set; } 

        public string UserType { get; set; } // Individual, Dealer, Investment, Self-use

        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public string? Comment { get; set; } 

        public DateTime EnquiryDate { get; set; } = DateTime.Now;
    }
}
