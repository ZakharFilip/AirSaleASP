using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirStore.Models
{
    public class ProdCharacter
    {
        [Key]
        public int? IdProdCharacter { get; set; }

        [ForeignKey("Product")]
        public int? IdProduct { get; set; }

        [ForeignKey("Characteristic")]
        public int? IdCharacteristic { get; set; }

        // Навигационные свойства для связи с Product и Characteristic
        public Product? Product { get; set; }
        public Characteristic? Characteristic { get; set; }
    }
}
