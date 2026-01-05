using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectZApi.Domain.Entities
{
    public class Property
    {
        // Basic Details
        [Key]
        public int Id { get; set; }
        public string PropertyName { get; set; }
        public string? Configuration { get; set; } //3bhk, 4bhk
        public int? UserId { get; set; } // SellerID or AgentID who post the property
       
        public User User { get; set; }
        public string? PostType { get; set; } // Enum: Rent/Sale

         // Foreign Key for PropertyType
        public int PropertyTypeId { get; set; } // Foreign Key
        [ForeignKey("PropertyTypeId")]
        public PropertyType PropertyType { get; set; } // Navigation property
        // Forignkey to Location
        public int? LocationId { get; set; }
        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        // Location Details
        public string? PlotNo { get; set; }
        public string? RoadNo { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string? Pincode { get; set; }
        public string? Landmark { get; set; }

        // Pricing Details
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ExpectedPrice { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? BasePricePerSqft { get; set; }

        // Area Information
        public double? CarpetArea { get; set; }
        public double? BuiltUpArea { get; set; }
        public double? SuperBuiltUpArea { get; set; }

        // Construction Details
        public int? PropertyAge { get; set; }
        public string? ConstructionStatus { get; set; } // Enum: Under Construction / Ready to Move
        public string? Furnishing { get; set; } // Enum: Unfurnished / Semi-furnished / Fully-furnished
        public int? FloorNo { get; set; }
        public int? TotalFloors { get; set; }

        // Rooms Information
        public int? Bedrooms { get; set; }
        public int? Bathrooms { get; set; }
        public int? Balconies { get; set; }
        public int? Halls { get; set; }

        // RERA and Approval
        public int? SellerId { get; set; } // Link property to seller

        [ForeignKey("SellerId")]
        public User Seller { get; set; }
        public RERAStatus RStatus { get; set; } = RERAStatus.NotVerified;
        public KYCStatus KYCStatus { get; set; } = KYCStatus.NotVerified;
        public string? RegistrationNumber { get; set; } //property registration on 7/12
        public string? UploadReraFilePath { get; set; }
        public string? KYCFilePath { get; set; }

        public PropertyStatus Status { get; set; } = PropertyStatus.Pending; // Default status// Enum: Approved / Rejected / Pending

        // Dates
        public DateTime PossessionDate { get; set; }
        public DateTime PostedDate { get; set; }

        // Media
        public List<string?> Images { get; set; } = new List<string>();
        public string? VideoURL { get; set; } // Optional

        // Additional Details
        public string? Facing { get; set; } // Enum: East, West, North, South
        public string? PropertyCategory { get; set; } // Enum: Primary / Resale
        public List<string?> Amenities { get; set; } = new List<string>(); // List of amenities
        public string? GoogleMapEmbedLink { get; set; } // location link
        public string? AvailabilityStatus { get; set; } // Enum: Available / Booked / Sold
        public bool? BoostedListing { get; set; } // For premium listings
        

        
        public ICollection<Review> Reviews { get; set; }
    }

    public enum PropertyStatus
    {
        Pending,   // Default when a seller submits a property
        Approved,  // Visible on the website once admin approves
        Rejected   // Hidden if admin rejects
    }
    public enum RERAStatus
    {
        NotVerified,
        PendingVerification,
        Verified
    }
    public enum KYCStatus
    {
        NotVerified,          
        PendingVerification,  
        Verified             
    }


}
