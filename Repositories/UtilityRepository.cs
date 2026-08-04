using Microsoft.EntityFrameworkCore;
using rental_system.Data;
using rental_system.Models.Entities;
namespace rental_system.Repositories
{
    public class UtilityRepository:IUtilityRepository
    {   
        private readonly AppDbContext _context;
        public UtilityRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task <List<AddPropertyEntity>> GetPropertiesAsync(int OwnerId)
        {
            return await _context.Properties.AsNoTracking().Where(P => P.Id == OwnerId).ToListAsync();
        }

        public async Task<List<AddRoomEntity>> GetRoomsAsync(int PropertyId)
        {
            return await _context.Rooms.AsNoTracking().Where(R=> R.PropertyId ==  PropertyId).ToListAsync();
        }
    }
}
