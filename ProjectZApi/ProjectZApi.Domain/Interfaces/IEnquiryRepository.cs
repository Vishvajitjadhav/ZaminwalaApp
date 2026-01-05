using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectZApi.Domain.Entities;

namespace ProjectZApi.Domain.Interfaces
{
    public interface IEnquiryRepository
    {
        Task AddEnquiryAsync(Enquiry enquiry); // Store enquiry
        Task<IEnumerable<Enquiry>> GetEnquiriesByPropertyAsync(int propertyId); // Fetch enquiries for a property
    }
}
