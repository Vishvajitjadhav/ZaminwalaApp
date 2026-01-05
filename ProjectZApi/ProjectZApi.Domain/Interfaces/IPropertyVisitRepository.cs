using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectZApi.Domain.Interfaces
{
    public interface IPropertyVisitRepository
    {
        Task AddVisitAsync(int propertyId, string visitorType); // Record a visit
        Task<int> GetVisitCountAsync(int propertyId); // Get the total visit count for a property
    }
}
