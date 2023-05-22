using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RostrosFelices.Data;
using RostrosFelices.Models;

namespace RostrosFelices.Pages.Clientes
{
    public class CrearModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CrearModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cliente Cliente { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Verificar que no exista otro cliente con el mismo NombreCompleto, excluyendo al cliente actual
            bool nombreCompletoExists = _context.Clientes.Any(c => c.Id != Cliente.Id && c.NombreCompleto == Cliente.NombreCompleto);
            if (nombreCompletoExists)
            {
                ModelState.AddModelError(string.Empty, "Ya existe otro cliente con el mismo Nombre Completo.");
                return Page();
            }

            // Verificar que no exista otro cliente con el mismo CorreoElectronico, excluyendo al cliente actual
            bool correoExists = _context.Clientes.Any(c => c.Id != Cliente.Id && c.CorreoElectronico == Cliente.CorreoElectronico);
            if (correoExists)
            {
                ModelState.AddModelError(string.Empty, "Ya existe otro cliente con el mismo Correo Electrónico.");
                return Page();
            }

            // Verificar que no exista otro cliente con el mismo NumeroTelefonico, excluyendo al cliente actual
            bool telefonoExists = _context.Clientes.Any(c => c.Id != Cliente.Id && c.NumeroTelefonico == Cliente.NumeroTelefonico);
            if (telefonoExists)
            {
                ModelState.AddModelError(string.Empty, "Ya existe otro cliente con el mismo Teléfono.");
                return Page();
            }

            // Verificar que no exista otro cliente con la misma CedulaCiudadania, excluyendo al cliente actual
            bool cedulaExists = _context.Clientes.Any(c => c.Id != Cliente.Id && c.CedulaCiudadania == Cliente.CedulaCiudadania);
            if (cedulaExists)
            {
                ModelState.AddModelError(string.Empty, "Ya existe otro cliente con la misma Cédula de Ciudadanía.");
                return Page();
            }

            _context.Update(Cliente);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}