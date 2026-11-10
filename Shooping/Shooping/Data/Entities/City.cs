using System.ComponentModel.DataAnnotations;

namespace Shooping.Data.Entities
{
    public class City
    {
        public int Id { get; set; }
        [Display(Name = "País")]
        [MaxLength(50, ErrorMessage = "El Campo {0} debe tener maximo {1}")]
        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        public string Name { get; set; }

        public State State { get; set; }

    }
}
