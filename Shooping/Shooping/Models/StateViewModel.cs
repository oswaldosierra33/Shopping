using System.ComponentModel.DataAnnotations;

namespace Shooping.Models
{
    public class StateViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Departamento/Estado")]
        [MaxLength(50, ErrorMessage = "El Campo {0} debe tener maximo {1}")]
        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        public string Name { get; set; }

        public int CountryId { get; set; }
    }
}
