using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace rental_system.Models.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string Phone { get; set; }
        public required string PasswordHash { get; set; }
        public string? Email { get; set; }
        public bool Status { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ModifiedAt { get; set; } = DateTime.Now;
    }
}
