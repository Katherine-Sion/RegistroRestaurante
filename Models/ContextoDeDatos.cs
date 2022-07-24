using Microsoft.EntityFrameworkCore;

namespace RegistroRestaurante.Models
{
    public class ContextoDeDatos : DbContext
    {
        public ContextoDeDatos(DbContextOptions<ContextoDeDatos> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Reservacion> Reservaciones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
