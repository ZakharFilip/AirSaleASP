using System.ComponentModel.DataAnnotations;

namespace AirStore.Models
{
    public class Product
    {
        [Key]
        public int? IdProduct { get; set; }

        public string? Name { get; set; }

        public string? Diskription { get; set; }

        public string? ImagePath { get; set; }

        public int? Price { get; set; }

        // Навигационное свойство для связи с ProdCharacter
        public ICollection<ProdCharacter>? ProdCharacters { get; set; }

        // Навигационное свойство для связи с SuperBusket
        public ICollection<SuperBusket>? SuperBuskets { get; set; }
    }
}
