using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectZApi.Domain.Entities;
using ProjectZApi.Domain.Interfaces;
using ProjectZApi.Infrastructure.Data;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using ProjectZApi.Helpers.SmsHelper;

namespace ProjectZApi.Infrastructure.Repositories
{
    public class OTPRepository : IOTPRepository
    {
        private readonly ProjectZDbContext _context;
        public OTPRepository(ProjectZDbContext context)
        {
            _context = context;
        }

        public async Task<bool> GenerateOTPAsync(string phone)
        {
            var otp = new OTP
            {
                Phone = phone,
                Code = new Random().Next(100000, 999999).ToString(),
                Expiration = DateTime.UtcNow.AddMinutes(5),
                IsUsed = false
            };

            _context.OTPs.Add(otp);
            await _context.SaveChangesAsync();

            // Send OTP via SMS (Twilio or other provider)
            SmsHelper.SendOTPViaSMS(phone, otp.Code);

            return true;
        }

        public async Task<bool> VerifyOTPAsync(string phone, string otp)
        {
            var existingOtp = await _context.OTPs
            .FirstOrDefaultAsync(o => o.Phone == phone && o.Code == otp && !o.IsUsed && o.Expiration > DateTime.UtcNow);

            if (existingOtp != null)
            {
                existingOtp.IsUsed = true;
                await _context.SaveChangesAsync();
                return true; // OTP is valid
            }

            return false; // OTP invalid or expired
        }
    }
}
