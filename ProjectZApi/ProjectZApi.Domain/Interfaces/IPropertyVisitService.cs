using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectZApi.Domain.Interfaces
{
    public interface IPropertyVisitService
    {
        Task AddVisitAsync(int propertyId, string visitorType);
        Task<int> GetVisitCountAsync(int propertyId);
    }
}
