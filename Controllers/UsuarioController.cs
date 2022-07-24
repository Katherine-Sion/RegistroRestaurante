using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistroRestaurante.Models;

namespace RegistroRestaurante.Controllers
{
    public class UsuarioController : Controller
    {
        //Consumir la inyección de dependencias por medio del constructor
        private readonly ContextoDeDatos _contexto;
        public UsuarioController(ContextoDeDatos contexto)
        {
            _contexto = contexto;
        }
        /// <summary>
        /// Acción que muestra el listado de contactos de la bd
        /// </summary>
        /// <returns>View</returns>
        public async Task<IActionResult> Index()
        {
            var listaUsuarios = await _contexto.Usuarios.ToListAsync();
            return View(listaUsuarios);
        }
        /// <summary>
        /// Acción que muestra el detalle de un usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View</returns>
        public async Task<IActionResult> Details(int id)
        {
            var usuario = await _contexto.Usuarios.FirstOrDefaultAsync(c => c.Id == id);
            return View(usuario);
        }
        /// <summary>
        /// Acción que muestra el formulario para un ragistro nuevo
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Acción que recibe los datos del formulario y los envia a la bd por medio de EF
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>RedirectToAction</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            _contexto.Add(usuario);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
  
        }
        /// <summary>
        ///  Acción que mustra el formulario con los datos de usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View</returns>
        public async Task<IActionResult> Edit(int id)
        {
            var Usuario = await _contexto.Usuarios.FirstOrDefaultAsync(c => c.Id == id);
            return View(Usuario);
        }
        /// <summary>
        /// Acción que recibe los datos modificados y los envia a la db por medio de entityfamework
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>RedirectToAction</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Usuario usuario)
        {
            _contexto.Update(usuario);
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
            var usuario = await _contexto.Usuarios.FirstOrDefaultAsync(c => c.Id == id);
            return View();
        }
        /// <summary>
        /// Acción que recibe la confirmación para eliminar el contacto
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>RedirectToAction</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Usuario usuario)
        {
            _contexto.Usuarios.Remove(usuario);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
