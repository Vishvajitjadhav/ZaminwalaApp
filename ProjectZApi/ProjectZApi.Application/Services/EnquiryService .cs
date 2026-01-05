using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ProjectZApi.Domain.DTOs;
using ProjectZApi.Domain.Entities;
using ProjectZApi.Domain.Interfaces;

namespace ProjectZApi.Application.Services
{
    public class EnquiryService : IEnquiryService
    {
        private readonly IEnquiryRepository _repository;

        public EnquiryService(IEnquiryRepository repository)
        {
            _repository = repository;
        }

        public async Task SubmitEnquiryAsync(EnquiryDTO enquiryDTO)
        {
            var enquiry = new Enquiry
            {
                PropertyId = enquiryDTO.PropertyId,
                UserType = enquiryDTO.UserType,
                Name = enquiryDTO.Name,
                Email = enquiryDTO.Email,
                PhoneNumber = enquiryDTO.PhoneNumber,
                Comment = enquiryDTO.Comment
            };

            await _repository.AddEnquiryAsync(enquiry);

            // Send notification after submitting
            await SendEnquiryNotificationAsync(enquiryDTO);
        }

        public async Task<IEnumerable<EnquiryDTO>> GetEnquiriesByPropertyAsync(int propertyId)
        {
            var enquiries = await _repository.GetEnquiriesByPropertyAsync(propertyId);
            return enquiries.Select(e => new EnquiryDTO
            {
                PropertyId = e.PropertyId,
                UserType = e.UserType,
                Name = e.Name,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                Comment = e.Comment
            }).ToList();
        }

        public async Task SendEnquiryNotificationAsync(EnquiryDTO enquiryDTO)
        {
            // Simulated Email Sending
            using (var smtp = new SmtpClient("smtp.example.com"))
            {
                var mail = new MailMessage
                {
                    From = new MailAddress("admin@example.com"),
                    Subject = $"New Enquiry for Property #{enquiryDTO.PropertyId}",
                    Body = $"Dear Seller,\n\nYou have received an enquiry.\n\nName: {enquiryDTO.Name}\nEmail: {enquiryDTO.Email}\nPhone: {enquiryDTO.PhoneNumber}\nMessage: {enquiryDTO.Comment}\n\nBest Regards, Your Team"
                };

                mail.To.Add("seller@example.com"); // Fetch seller's email dynamically
                smtp.Send(mail);
            }

            // Simulated SMS Sending
            Console.WriteLine($"SMS Sent to Seller: Enquiry from {enquiryDTO.Name}, Contact: {enquiryDTO.PhoneNumber}");
        }
    }
}
