using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectZApi.Domain.Interfaces;

namespace ProjectZApi.Application.Services
{
    public class PropertyVisitService : IPropertyVisitService
    {
        private readonly IPropertyVisitRepository _repository;
        public PropertyVisitService(IPropertyVisitRepository repository)
        {
            _repository = repository;
           
        }

        public async Task AddVisitAsync(int propertyId, string visitorType)
        {
            // Pass the visit data to the repository
            await _repository.AddVisitAsync(propertyId, visitorType);
        }

        public async Task<int> GetVisitCountAsync(int propertyId)
        {
            // Get the total visit count from the repository
            return await _repository.GetVisitCountAsync(propertyId);
        }
    }
}
