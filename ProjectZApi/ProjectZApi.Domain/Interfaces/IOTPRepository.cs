using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectZApi.Domain.Interfaces
{
    public interface IOTPRepository
    {
        Task<bool> GenerateOTPAsync(string phone);
        Task<bool> VerifyOTPAsync(string phone, string otp);
    }
}
