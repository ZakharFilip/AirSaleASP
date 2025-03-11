using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirStore.Models
{
    public class SuperBusket
    {
        [Key]
        public int? IdSuperBasket { get; set; }

        [ForeignKey("User")]
        public int? IdUser { get; set; }

        [ForeignKey("Product")]
        public int? IdProduct { get; set; }

        public bool? Visibility { get; set; }

        // Навигационные свойства для связи с User и Product
        public User? User { get; set; }
        public Product? Product { get; set; }
    }
}
