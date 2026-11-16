using System.ComponentModel.DataAnnotations;

namespace Shooping.Models
{
    public class CityViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Ciudad")]
        [MaxLength(50, ErrorMessage = "El Campo {0} debe tener maximo {1}")]
        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        public string Name { get; set; }

        public int StateId { get; set; }
    }
}
