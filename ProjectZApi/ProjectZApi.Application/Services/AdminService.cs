using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectZApi.Domain.Entities;
using ProjectZApi.Domain.Interfaces;

namespace ProjectZApi.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _repository;
        public AdminService(IAdminRepository repository)
        {
            _repository = repository;
        }

        public async Task ApproveSellerAsync(int SellerStatusId)
        {
            await _repository.ApproveSellerAsync(SellerStatusId);
        }

        public async Task<IEnumerable<SellerStatus>> GetPendingSellerAsync()
        {
            return await _repository.GetPendingSellerAsync();
        }

        public async Task RejectSellerAsync(int SellerStatusId)
        {
            await _repository.RejectSellerAsync(SellerStatusId);
        }


        public User ValidateAdmin(string username, string password)
        {
            return _repository.ValidateAdmin(username, password);
        }
    }
}
