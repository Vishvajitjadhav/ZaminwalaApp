using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectZApi.Domain.Entities
{
    public class PropertyType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } // E.g., "Residential", "Commercial", "Villa/Bungalow"
    }
}
