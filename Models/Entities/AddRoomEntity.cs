using System.ComponentModel.DataAnnotations;

namespace rental_system.Models.Entities
{
    public class AddRoomEntity
    {
        [Key]
        public int Id { get; set; }
        public required int RoomNo { get; set; }
        public required int  PropertyId { get; set; }
        public string? RoomName { get; set; }
        public int Rent { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ModifiedAt { get; set; } = DateTime.Now;

    }
}
