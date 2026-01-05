using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectZApi.Domain.DTOs;

namespace ProjectZApi.Domain.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<LocationDTO>> GetAllLocationsAsync(); // Fetch all locations
        Task AddLocationAsync(LocationDTO locationDTO);
    }
}
