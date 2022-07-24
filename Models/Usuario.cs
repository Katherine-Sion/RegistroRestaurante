using System.ComponentModel.DataAnnotations;

namespace RegistroRestaurante.Models
{
    public class Usuario
    {
        [Key]

        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(50, ErrorMessage = "La longitud maxima son 50 caracteres")]
        [Display(Name = "Nombre del usuario")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Teléfono es requerido")]
        [MaxLength(15, ErrorMessage = "La longitud maxima son 15 caracteres")]
        [MinLength(8, ErrorMessage = "La longitud maxima son 8 caracteres")]
        public string Teléfono { get; set; }

        [Required(ErrorMessage = "El Email es requerido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La clave es requerida")]
        [MaxLength(10, ErrorMessage = "La longitud maxima son 10 caracteres")]
        [MinLength(8, ErrorMessage = "La longitud maxima son 8 caracteres")]

        public string Clave { get; set; }

        public List<Reservacion> Reservaciones { get; set; }
    }
}

