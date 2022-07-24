using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistroRestaurante.Models;

namespace RegistroRestaurante.Controllers
{
    public class ReservacionController : Controller
    {
        //consumir la inyección de dependencias mediante el constructor
        private readonly ContextoDeDatos _contexto;
        public ReservacionController(ContextoDeDatos contexto)
        {
            _contexto = contexto;
        }
        /// <summary>
        /// Acción que muestra el listado de reservaciones registradas
        /// </summary>
        /// <returns>View</returns>
        public async Task<IActionResult> Index()
        {
            var listaReservaciones = await _contexto.Reservaciones.Include(c => c.Cliente ).ToListAsync();
            ViewBag.Usuarios = await _contexto.Usuarios.ToListAsync();
            return View(listaReservaciones);
        }
        /// <summary>
        /// Acción que muestra el detalle de un registro
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View</returns>
        public async Task<IActionResult> Details(int id)
        {
            var reservacion = await _contexto.Reservaciones.Include(c => c.Cliente).FirstOrDefaultAsync(e => e.Id == id);
            ViewBag.Usuarios = await _contexto.Usuarios.ToListAsync();
            return View(reservacion);
        }
        /// <summary>
        /// Acción que muesta el formulario para agregar una empresa
        /// </summary>
        /// <returns>View</returns>
        public async Task<IActionResult> Create()
        {
            ViewBag.Clientes = await _contexto.Clientes.ToListAsync();
            ViewBag.Usuarios = await _contexto.Usuarios.ToListAsync();
            return View();
        }
        /// <summary>
        /// Acción que recibe los datos del formulario y los envía a la bd por medio de EF
        /// </summary>
        /// <param name="reservacion"></param>
        /// <returns>RedirectToAction</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reservacion reservacion)
        {
            _contexto.Reservaciones.Add(reservacion);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// Acción que muestra el formulario con los datos de la empresa
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View</returns>
        public async Task<IActionResult> Edit(int id)
        {
            var reservacion = await _contexto.Reservaciones.Include(c => c.Cliente).FirstOrDefaultAsync(e => e.Id == id);
            ViewBag.Clientes = await _contexto.Clientes.ToListAsync();
            ViewBag.Usuarios = await _contexto.Usuarios.ToListAsync();
            return View(reservacion);
        }
        /// <summary>
        /// Acción que recibe los datos modificados para enviarlos a la bd
        /// </summary>
        /// <param name="reservacion"></param>
        /// <returns>RedirectToAction</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Reservacion reservacion)
        {
            _contexto.Reservaciones.Update(reservacion);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// Acción que muestre los datos del registro para confirmar la eliminación
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View</returns>
        public async Task<IActionResult> Delete(int id)
        {
            var reservacion = await _contexto.Reservaciones.Include(c => c.Cliente).FirstOrDefaultAsync(e => e.Id == id);
            return View(reservacion);
        }
        /// <summary>
        /// Acción que recibe la confirmación para eliminar el registro
        /// </summary>
        /// <param name="reservacion"></param>
        /// <returns>RedirectToAction</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Reservacion reservacion)
        {
            _contexto.Reservaciones.Remove(reservacion);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
