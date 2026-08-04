using System.ComponentModel.DataAnnotations;

namespace rental_system.Models.Dtos
{
    public class AddTenantDto
    {
       
        public required int OwnerId { get; set; }
        [Required]
        public required string FullName { get; set; }
        public string Address { get; set; } = "";
        [Required]
        public required string Phone { get; set; }
        [Required]
        public required string AdhaarIdNo { get; set; }

    }
}
