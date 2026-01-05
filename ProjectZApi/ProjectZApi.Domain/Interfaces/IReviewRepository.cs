using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectZApi.Domain.Entities;

namespace ProjectZApi.Domain.Interfaces
{
    public interface IReviewRepository
    {
        Task AddReviewAsync(Review review);
        Task<IEnumerable<Review>> GetReviewsByPropertyIdAsync(int propertyId); // Get reviews for a specific property
    }
}
