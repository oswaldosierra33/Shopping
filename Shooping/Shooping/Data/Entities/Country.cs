using System.ComponentModel.DataAnnotations;

namespace Shooping.Data.Entities
{
    public class Country
    {
        public int Id { get; set; }
        [Display(Name = "Pais")]
        [MaxLength(50, ErrorMessage = "El Campo {0} debe tener maximo {1}")]
        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        public string Name { get; set; }
    }
}
