using rental_system.Models.Dtos;

namespace rental_system.Interfaces.IRepositories
{
    public interface IPropertyRepository
    {
        public Task<AddPropertyDto> AddPropertyAsync(AddPropertyDto property);

        public Task<AddRoomDto> AddNewRoomAsync(AddRoomDto room);
    }
}
