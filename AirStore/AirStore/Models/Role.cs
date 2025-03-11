using System.ComponentModel.DataAnnotations;

namespace AirStore.Models
{
    public class Role
    {
        [Key]
        public int IdRole { get; set; }

        [Required]
        [MaxLength(50)]
        public string? RoleName { get; set; }

        // Навигационное свойство для связи с User
        public ICollection<User>? Users { get; set; }
    }
}
