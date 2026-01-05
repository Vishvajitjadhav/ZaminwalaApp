using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectZApi.Domain.DTOs;
using ProjectZApi.Domain.Entities;
using ProjectZApi.Domain.Interfaces;

namespace ProjectZApi.Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _repository;

        public ReviewService(IReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task AddReviewAsync(ReviewDTO reviewDTO)
        {
            var review = new Review
            {
                UserId = reviewDTO.UserId,
                PropertyId = reviewDTO.PropertyId,
                Comments = reviewDTO.Comments,
                Rating = reviewDTO.Rating
            };

            await _repository.AddReviewAsync(review);
        }

        public async Task<IEnumerable<Review>> GetReviewsByPropertyIdAsync(int propertyId)
        {
            return await _repository.GetReviewsByPropertyIdAsync(propertyId);
        }
    }
}