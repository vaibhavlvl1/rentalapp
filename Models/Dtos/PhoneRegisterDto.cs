using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace rental_system.Models.Dtos
{
    public class PhoneRegisterDto
    {
        [Required]
        public required string FullName { get; set; }
        [Required]
        [MinLength(10)]
        public required string Phone { get; set; }
        
        public string? Email { get; set; }
        [Required]
        [MinLength(8)]
        public required string Password { get; set; }
        
    }
}
