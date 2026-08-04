using rental_system.Models.Dtos;

namespace rental_system.Interfaces.IServices
{
    public interface IUserService
    {
        public Task<ApiResponseDto> RegisterUserAsync(PhoneRegisterDto phone);
        public Task<ApiResponseDto> CreateNewTenantAsync(AddTenantDto tenant);
    }
}
