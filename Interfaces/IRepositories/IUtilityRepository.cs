using rental_system.Models.Entities;



public interface IUtilityRepository
{
    public Task<List<AddPropertyEntity>> GetPropertiesAsync(int OwnerId);
    public Task<List<AddRoomEntity>> GetRoomsAsync(int PropertyId);
}