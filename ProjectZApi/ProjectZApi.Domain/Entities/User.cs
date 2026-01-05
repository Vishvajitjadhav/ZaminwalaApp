using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectZApi.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; }

        [Phone]
        [MaxLength(15)]
        public string Phone { get; set; }

        [Required]
        
        public string Password { get; set; }

        public int? RoleId { get; set; } // FK to Role

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        

        
        public Role Role { get; set; } // Navigation properties
        public ICollection<Property>? Properties { get; set; }



    }   
}
