namespace rental_system.Models.Dtos
{
    public class PropertyTenantMapDto
    {
        public int RoomId { get; set; }
        public int TenantId { get; set; }

        public  DateTime DateMovedIn {  get; set; }
        public DateTime DateMovedOut { get; set; }

        
    }
}
