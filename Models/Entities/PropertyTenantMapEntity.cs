using System.ComponentModel.DataAnnotations;

namespace rental_system.Models.Entities
{
    public class PropertyTenantMapEntity
    {
        [Key]
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int TenantId { get; set; }

        public DateTime DateMovedIn { get; set; } 
        public DateTime? DateMovedOut { get; set; } 
        public bool Status { get; set; }
    }
}
