using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectZApi.Domain.DTOs;

namespace ProjectZApi.Domain.Interfaces
{
    public interface IEnquiryService
    {
        Task SubmitEnquiryAsync(EnquiryDTO enquiryDTO); // Save an enquiry
        Task<IEnumerable<EnquiryDTO>> GetEnquiriesByPropertyAsync(int propertyId); // Get enquiries
        Task SendEnquiryNotificationAsync(EnquiryDTO enquiryDTO); // Send email/SMS to seller
    }
}
