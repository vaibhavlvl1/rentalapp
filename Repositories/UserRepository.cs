using rental_system.Data;
using rental_system.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using rental_system.Models.Entities;
using rental_system.Models.Dtos;

namespace rental_system.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckUserInDbAsync(string Phone)
        {
            var User = await _context.Users.AnyAsync(x => x.Phone == Phone);

            return User;
        }

        public async Task<UserEntity> FetchUserFromDbAsync(string Phone)
        {
            var User = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Phone == Phone);

            return User;
        }

        public async Task<UserEntity> CreateNewUserAsync(UserEntity User)
        {
            await _context.Users.AddAsync(User);

            await _context.SaveChangesAsync();

            return User;
        }

        public async Task<bool> CheckPasswordMatchAsync(string phone, string hashedPassword)
        {
            return await _context.Users.AnyAsync(x => x.Phone == phone);

        }

        public async Task<AddTenantEntity> CreateNewTenantAsync(AddTenantEntity tenant)
        {

            await _context.Tenants.AddAsync(tenant);

            await _context.SaveChangesAsync();

            return tenant;
        }

        public async Task<UserEntity>GetUserByEmailAsync(string Email)
        {
           return await _context.Users.FirstOrDefaultAsync(x => x.Email == Email);
        }

       
    }
}
