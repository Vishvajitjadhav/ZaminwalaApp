using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectZApi.Domain.Entities;

namespace ProjectZApi.Domain.Interfaces
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetAllLocationsAsync(); // Get all locations
        Task AddLocationAsync(Location location); // Add a new location (Admin only)
    }
}
