using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectZApi.Domain.Entities;

namespace ProjectZApi.Domain.Interfaces
{
    public interface ISellerRepository
    {
        Task<User> ValidateSellerAsync(string email, string password);
    }
}
