using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectZApi.Domain.DTOs;

namespace ProjectZApi.Domain.Interfaces
{
    public interface IOTPService
    {
        Task<bool> SendOTPAsync(SendOTPDTO sendOTPDTO);
        Task<bool> ValidateOTPAsync(VerifyOTPDTO verifyOTPDTO);
    }
}
