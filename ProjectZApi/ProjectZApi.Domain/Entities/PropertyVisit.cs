using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectZApi.Domain.Entities
{
    public class PropertyVisit
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        public int PropertyId { get; set; } // FK to Property(the property being visited)

        public string? VisitorType { get; set; } // "Registered" or "Non-Registered"

        [Required]
        public DateTime VisitDateTime { get; set; } 
    }
}

