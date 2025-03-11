using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirStore.Models
{
    public class User
    {
        
            [Key]
            public int? IdUser { get; set; }

            [ForeignKey("Role")]
            public int? IdRole { get; set; }

            // Навигационное свойство для связи с Role
            public Role? Role { get; set; }

            // Навигационное свойство для связи с SuperBusket
            public ICollection<SuperBusket>? SuperBuskets { get; set; }
        
    }
}
