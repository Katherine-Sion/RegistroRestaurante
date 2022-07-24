using System.ComponentModel.DataAnnotations;

namespace RegistroRestaurante.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(50, ErrorMessage = "La longitud maxima son 50 caracteres")]
        [Display(Name = "Nombre del cliente")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Teléfono es requerido")]
        [MaxLength(15, ErrorMessage = "La longitud maxima son 15 caracteres")]
        [MinLength(8, ErrorMessage = "La longitud maxima son 8 caracteres")]
        public string Teléfono { get; set; }

        [Required(ErrorMessage = "El Email es requerido")]
        public string Email { get; set; }


        [Required(ErrorMessage = "La Dirección es requerida")]
        [MaxLength(90, ErrorMessage = "La longitud maxima son 90 caracteres")]
        [MinLength(20, ErrorMessage = "La longitud maxima son 20 caracteres")]
        public string Dirección { get; set; }

        public List<Reservacion> Reservaciones { get; set; }

    }
}
