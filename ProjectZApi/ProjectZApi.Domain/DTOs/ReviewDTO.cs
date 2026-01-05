using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectZApi.Domain.DTOs
{
    public class ReviewDTO
    {
        public int UserId { get; set; } 
        public int PropertyId { get; set; } 
        public string Comments { get; set; } 
        public int Rating { get; set; } //(1-5 stars)
    }
}
