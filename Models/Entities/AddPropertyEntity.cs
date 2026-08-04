using System.ComponentModel.DataAnnotations;

namespace rental_system.Models.Entities
{
    public class AddPropertyEntity
    {
        [Key]
        public int Id { get; set; }
        public required string PropertyName { get; set; }
        public string? Address { get; set; }
        public required int OwnerId { get; set; }
        public bool IsPropertyActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ModifiedAt { get; set; } = DateTime.Now;
    }
}
