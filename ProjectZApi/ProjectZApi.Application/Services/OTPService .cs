using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectZApi.Domain.DTOs;
using ProjectZApi.Domain.Interfaces;

namespace ProjectZApi.Application.Services
{
    public class OTPService : IOTPService
    {
        private readonly IOTPRepository _repository;

        public OTPService(IOTPRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> SendOTPAsync(SendOTPDTO sendOTPDTO)
        {
            return await _repository.GenerateOTPAsync(sendOTPDTO.Phone);
        }

        public async Task<bool> ValidateOTPAsync(VerifyOTPDTO verifyOTPDTO)
        {
            return await _repository.VerifyOTPAsync(verifyOTPDTO.Phone, verifyOTPDTO.Code);
        }
    }
}
