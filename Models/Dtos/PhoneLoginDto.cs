using System.ComponentModel.DataAnnotations;

namespace rental_system.Models.Dtos
{
    public class PhoneLoginDto
    {
        [Required]
        [MaxLength(15)]
        public required string Phone { get; set; }
        [Required]
        [MinLength(8)]
        public required string Password { get; set; }
    }
}
