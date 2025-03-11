using System.ComponentModel.DataAnnotations;

namespace AirStore.Models
{
    public class Characteristic
    {
        
            [Key]
            public int? IdCharacteristic { get; set; }

            [Required]
            [MaxLength(50)]
            public string? CharName { get; set; }

            public string? Description { get; set; }

            // Навигационное свойство для связи с ProdCharacter
            public ICollection<ProdCharacter>? ProdCharacters { get; set; }
        
    }
}
