using rental_system.Models.Dtos;
using rental_system.Models.Entities;

namespace rental_system.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        public Task<bool> CheckUserInDbAsync(string phone);
        public Task<UserEntity> CreateNewUserAsync(UserEntity user);
        public Task<UserEntity> FetchUserFromDbAsync(string Phone);
        public Task<bool> CheckPasswordMatchAsync(string phone,string hashedPassword);
        public Task<AddTenantEntity> CreateNewTenantAsync(AddTenantEntity tenant);
        public Task<UserEntity> GetUserByEmailAsync(string Email);
    }
}
