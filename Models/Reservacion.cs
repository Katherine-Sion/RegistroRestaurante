using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroRestaurante.Models
{
    public class Reservacion
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("Cliente")]
        [Required(ErrorMessage = "El Cliente es requerido")]
        [Display(Name = "Nombre del Cliente")]
        public int ClienteId { get; set; }


        [ForeignKey("Usuario")]
        [Required(ErrorMessage = "El Usuario es requerido")]
        [Display(Name = "Nombre del Usuario")]
        public int UsuarioId { get; set; }


        [Required(ErrorMessage = "La mesa es requerida")]
        public string Mesa { get; set; }

        [Required(ErrorMessage = "La Fecha es requerida ")]
        [DataType(DataType.Date)]
        public string Fecha { get; set; }

        [Required(ErrorMessage = "La hora es requerida")]
        [DataType(DataType.Time)]
        public string Hora { get; set; }

        [Required(ErrorMessage = "El precio es requerido")]
        public decimal Precio { get; set; }

        public Cliente Cliente { get; set; }
        public Usuario Usuario { get; set; }
    }
}
