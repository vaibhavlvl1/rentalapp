using rental_system.Data;
using rental_system.Interfaces.IRepositories;
using rental_system.Models.Dtos;
using rental_system.Models.Entities;

namespace rental_system.Repositories
{
    public class PropertyRepository:IPropertyRepository
    {   
        private readonly AppDbContext _context;
        public PropertyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task <AddPropertyDto>  AddPropertyAsync(AddPropertyDto property)
        {   
            AddPropertyEntity propertyEntity = new AddPropertyEntity 
            { 
                OwnerId = property.OwnerId,
          
                PropertyName = property.PropertyName,

                Address = property.Address
            };

            await _context.Properties.AddAsync(propertyEntity);
            await _context.SaveChangesAsync();

            return property;
        }

        public async Task <AddRoomDto> AddNewRoomAsync(AddRoomDto room)
        {
            AddRoomEntity roomEntity = new AddRoomEntity
            {
                PropertyId = room.PropertyId,
                RoomNo = room.RoomNo,
                Rent = room.Rent,
                RoomName = room.RoomName
            };

            await _context.Rooms.AddAsync(roomEntity);
            await _context.SaveChangesAsync();

            return room;
        }
    }
}
