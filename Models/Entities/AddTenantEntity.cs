using System.ComponentModel.DataAnnotations;

namespace rental_system.Models.Entities
{
    public class AddTenantEntity
    {
        [Key]
        public int Id { get; set; }
        public required int OwnerId { get; set; }
        [Required]
        public required string FullName { get; set; }
        public string Address { get; set; } = "";
        [Required]
        public required string Phone { get; set; }
        [Required]
        public required string AdhaarIdNo { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ModifiedAt { get; set; } = DateTime.Now;
    }
}
