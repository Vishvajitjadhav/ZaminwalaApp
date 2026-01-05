using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectZApi.Domain.Entities;

namespace ProjectZApi.Domain.Interfaces
{
    public interface IAdminService
    {
        Task ApproveSellerAsync(int SellerStatusId);
        Task RejectSellerAsync(int SellerStatusId);
        Task<IEnumerable<SellerStatus>> GetPendingSellerAsync();

        User ValidateAdmin(string username, string password); //Admin Login
    }
}
