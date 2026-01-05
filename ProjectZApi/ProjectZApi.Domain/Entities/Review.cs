using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectZApi.Domain.Entities
{
    public class Review
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        public int UserId { get; set; } // FK to User/Buyer table

        [Required]
        public int PropertyId { get; set; } // FK to Property table

        [Required]
        [MaxLength(500)]
        public string Comments { get; set; } 

        [Required]
        public int Rating { get; set; } // Rating (1-5 stars)

        public DateTime ReviewedOn { get; set; } = DateTime.Now; // Date of review

        // Navigation properties
        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("PropertyId")]
        public Property Property { get; set; }
    }
}
