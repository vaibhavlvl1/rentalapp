using rental_system.Models.Dtos;

namespace rental_system.Interfaces.IServices
{
    public interface IAuthService
    {
        public Task <ApiResponseDto> LoginAsync(PhoneLoginDto phoneLoginRequest);

        public Task<ApiResponseDto> LoginOrRegisterGoogleUserAsync(GoogleLoginDto GoogleDetails);

        public Task<ApiResponseDto> DecodeTokenAsync();
    }
}
