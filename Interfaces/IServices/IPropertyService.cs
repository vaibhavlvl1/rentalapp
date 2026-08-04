using rental_system.Models.Dtos;

namespace rental_system.Interfaces.IServices
{
    public interface IPropertyService
    {
        public Task<ApiResponseDto> AddNewPropertyAsync(AddPropertyDto property);
        public Task<ApiResponseDto> AddNewRoomAsync(AddRoomDto room);
    }
}
