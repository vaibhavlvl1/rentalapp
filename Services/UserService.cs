using rental_system.Interfaces.IRepositories;
using rental_system.Interfaces.IServices;
using rental_system.Models.Dtos;
using rental_system.Models.Entities;
using BC = BCrypt.Net.BCrypt;

namespace rental_system.Services
{
    public class UserService:IUserService
    {   
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }



        public async Task<ApiResponseDto> RegisterUserAsync(PhoneRegisterDto PhoneRegistrationRequest)
        {

            // Check if user exixsts in DB if yes return with bad request
            var WhetherUserExists = await _userRepo.CheckUserInDbAsync(PhoneRegistrationRequest.Phone);


            if (WhetherUserExists)
            {

                return new ApiResponseDto
                {
                    status = 400,
                    message = "User Already Exists"
                };
            }


            // Hash the incoming password and submit to entity
            string hashedPassword = BC.HashPassword(PhoneRegistrationRequest.Password, workFactor: 11);

            var NewUser = new UserEntity
            {
                FullName = PhoneRegistrationRequest.FullName,
                Phone = PhoneRegistrationRequest.Phone,
                Email = PhoneRegistrationRequest.Email,
                PasswordHash = hashedPassword,

            };

            var response = await _userRepo.CreateNewUserAsync(NewUser);

            var createdUser = new { FullName = response.FullName, Phone = response.Phone,Email=response.Email };


            return new ApiResponseDto
            {
                status = 201,
                message = "User Has Been Created",
                data = createdUser
            };
        }

        public async Task<ApiResponseDto> CreateNewTenantAsync(AddTenantDto tenant)
        {
            var tenantIdentity = new AddTenantEntity
            {
                OwnerId = tenant.OwnerId,
                FullName = tenant.FullName,
                Phone = tenant.Phone,
                AdhaarIdNo = tenant.AdhaarIdNo,
                Address = tenant.Address,

            };

            var result = await _userRepo.CreateNewTenantAsync(tenantIdentity);

            if(result == null)
            {
                return new ApiResponseDto
                {
                    status = 500,
                    message = "Failed to Create a Tenant"
                };
            }

            return new ApiResponseDto
            {
                status = 200,
                message = "Created a Tenant Successfully",
                data = result
            };
        }
    }
}
