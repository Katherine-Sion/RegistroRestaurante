using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistroRestaurante.Models;

namespace RegistroRestaurante.Controllers
{
    public class ClienteController : Controller
    {
        // Consumir la inyección de dependencias por medio del constructor
        private readonly ContextoDeDatos _contexto;
        public ClienteController(ContextoDeDatos contexto)
        {
            _contexto = contexto;
        }
        /// <summary>
        /// Acción que muestra el listado de datos en la bd
        /// </summary>
        /// <returns>View</returns>
        public async Task<IActionResult> Index()
        {
            var listaClientes = await _contexto.Clientes.ToListAsync();
            return View(listaClientes);
        }

        /// <summary>
        /// Acción que muestra el detalle de un contacto
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View</returns>
        public async Task<IActionResult> Details(int id)
        {
            var cliente = await _contexto.Clientes.FirstOrDefaultAsync(c => c.Id == id);
            return View(cliente);
        }
        /// <summary>
        /// Acción que muestra el formulario para un registro nuevo
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Acción que resibe los datos del formulario y los envia a la bd por medio de EF
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns>RedirectToAction</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            _contexto.Add(cliente);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); ;
        }
        /// <summary>
        /// Acción que muestra el fomulario con los datos del cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View</returns>

        public async Task<IActionResult> Edit(int id)
        {
            var cliente = await _contexto.Clientes.FirstOrDefaultAsync(c => c.Id == id);
            return View(cliente);
        }
        /// <summary>
        /// Acción que resibe los datos modificados y los envia a la bd por medio de entityfamework
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns>RedirectToAction</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Cliente cliente)
        {
            _contexto.Update(cliente);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// Acción que muestra el registro para confirmar eliminación
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View</returns>
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _contexto.Clientes.FirstOrDefaultAsync(c => c.Id == id);
            return View();
        }
        /// <summary>
        /// Acción que resibe la confirmación para eliminar el cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns>RedirectToAction</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Cliente cliente)
        {
            _contexto.Clientes.Remove(cliente);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}
