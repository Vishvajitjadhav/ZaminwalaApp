using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectZApi.Domain.Entities;

namespace ProjectZApi.Domain.DTOs
{
    public class PropertyDTO
    {
        public string PropertyName { get; set; }
        public string Configuration { get; set; } //3bhk, 4bhk
        public int UserId { get; set; } // SellerID or AgentID
        public string PostType { get; set; } // Enum: Rent/Sale

        // Foreign Key for PropertyType
        public int PropertyTypeId { get; set; } // Foreign Key
        [ForeignKey("PropertyTypeId")]
        public PropertyType PropertyType { get; set; } // Navigation property

        // Location Details
        public string PlotNo { get; set; }
        public string RoadNo { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
        public string Landmark { get; set; }

        // Pricing Details
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ExpectedPrice { get; set; }
        //[Column(TypeName = "decimal(18, 2)")]
        //public decimal BasePricePerSqft { get; set; }

        // Area Information
        public double CarpetArea { get; set; }
        //public double BuiltUpArea { get; set; }
        //public double SuperBuiltUpArea { get; set; }

        // Construction Details
        public int PropertyAge { get; set; }
        //public string ConstructionStatus { get; set; } // Enum: Under Construction / Ready to Move
        //public string Furnishing { get; set; } // Enum: Unfurnished / Semi-furnished / Fully-furnished
        //public int FloorNo { get; set; }
        //public int TotalFloors { get; set; }

        // Rooms Information
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int Balconies { get; set; }
        public int Halls { get; set; }

        // RERA and Approval
        public RERAStatus RStatus { get; set; } = RERAStatus.NotVerified;

        public string? RegistrationNumber { get; set; } // 7/12 registration number
        public string? UploadReraFilePath { get; set; }
        public PropertyStatus Status { get; set; } = PropertyStatus.Pending;

        // Dates
        public DateTime PossessionDate { get; set; }
        public DateTime PostedDate { get; set; }

        // Media
        public List<string> Images { get; set; } = new List<string>();
        //public string VideoURL { get; set; } // Optional

        // Additional Details
        public string Facing { get; set; } // Enum: East, West, North, South
       // public string PropertyCategory { get; set; } // Enum: Primary / Resale
        public List<string> Amenities { get; set; } = new List<string>(); // List of amenities
        public string GoogleMapEmbedLink { get; set; } // location link
        public string AvailabilityStatus { get; set; } // Enum: Available / Booked / Sold
       // public bool BoostedListing { get; set; } // For premium listings
    }
}
