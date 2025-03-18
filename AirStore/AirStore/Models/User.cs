using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirStore.Models
{
    public class User
    {
        
            [Key]
            public int? IdUser { get; set; }

        [StringLength(50)]
        public string? Login { get; set; }

        [StringLength(50)]
            [Required]
            public string? Email { get; set; }
        public string? PasswordHash { get; set; }



        

        public int? IdRole { get; set; }
        [ForeignKey("IdRole")]
        // Навигационное свойство для связи с Role
        public Role? Role { get; set; }

            // Навигационное свойство для связи с SuperBusket
            public ICollection<SuperBusket>? SuperBuskets { get; set; }
        
    }
}
