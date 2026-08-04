namespace rental_system.Models.Dtos
{
    public class AddRoomDto
    {
        public int RoomNo { get; set; }
        public int PropertyId { get; set; }
        public string? RoomName { get; set; }
        public int Rent { get; set; }
    }
}
