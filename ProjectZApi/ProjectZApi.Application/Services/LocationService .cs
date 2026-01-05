using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectZApi.Domain.DTOs;
using ProjectZApi.Domain.Entities;
using ProjectZApi.Domain.Interfaces;

namespace ProjectZApi.Application.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _repository;
        public LocationService(ILocationRepository repository)
        {
            _repository = repository;
        }

        public async Task AddLocationAsync(LocationDTO locationDTO)
        {
            var location = new Location
            {
                City = locationDTO.City
            };

            await _repository.AddLocationAsync(location);
        }

        public async Task<IEnumerable<LocationDTO>> GetAllLocationsAsync()
        {
            var locations = await _repository.GetAllLocationsAsync();
            return locations.Select(l => new LocationDTO { City = l.City }).ToList();
        }
    }
}
