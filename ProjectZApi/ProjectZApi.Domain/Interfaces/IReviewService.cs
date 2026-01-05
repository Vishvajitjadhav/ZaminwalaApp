using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectZApi.Domain.DTOs;
using ProjectZApi.Domain.Entities;

namespace ProjectZApi.Domain.Interfaces
{
    public interface IReviewService
    {
        Task AddReviewAsync(ReviewDTO reviewDTO); // Add a new review
        Task<IEnumerable<Review>> GetReviewsByPropertyIdAsync(int propertyId); // Get reviews for a property
    }
}
