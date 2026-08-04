using System.ComponentModel.DataAnnotations;

namespace rental_system.Models.Dtos
{
    public class AddPropertyDto
    {
        [Required]
        public required string PropertyName { get; set; }
        public string? Address { get; set; }
        public required int  OwnerId { get; set; }
    }
}
