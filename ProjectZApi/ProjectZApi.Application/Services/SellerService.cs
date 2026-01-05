using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectZApi.Domain.Entities;
using ProjectZApi.Domain.Interfaces;

namespace ProjectZApi.Application.Services
{
    public class SellerService : ISellerServices
    {
        private readonly ISellerRepository _repository;
        public SellerService(ISellerRepository repository)
        {
            _repository = repository;
        }
        public async Task<User> ValidateSellerAsync(string email, string password)
        {
            return await _repository.ValidateSellerAsync(email, password);
        }

    }
    
    

}
