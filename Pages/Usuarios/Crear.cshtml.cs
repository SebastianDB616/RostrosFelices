using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RostrosFelices.Data;
using RostrosFelices.Models;

namespace RostrosFelices.Pages.Usuarios
{
    public class CrearModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CrearModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string NombreCompleto { get; set; }

        [BindProperty]
        public string CorreoElectronico { get; set; }

        [BindProperty]
        public string TipoSangre { get; set; }

        [BindProperty]
        public string CedulaCiudadania { get; set; }

        [BindProperty]
        public string NumeroTelefonico { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Contraseña { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ConfirmarContraseña { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Contraseña = string.Empty;
                ConfirmarContraseña = string.Empty;
                return Page();
            }

            if (Contraseña != ConfirmarContraseña)
            {
                ModelState.AddModelError("ConfirmarContraseña", "Las contraseñas no coinciden");
                return Page();
            }

            // Verificar si el correo electrónico ya está en uso
            if (_context.Usuarios.Any(u => u.NombreCompleto == NombreCompleto))
            {
                ModelState.AddModelError("NombreCompleto", "El nombre completo ya está en uso");
                return Page();
            }

            // Verificar si el nombre completo ya está en uso
            if (_context.Usuarios.Any(u => u.CorreoElectronico == CorreoElectronico))
            {
                ModelState.AddModelError("CorreoElectronico", "El correo electrónico ya está en uso");
                return Page();
            }

            // Verificar si la cédula de ciudadanía ya está en uso
            if (_context.Usuarios.Any(u => u.CedulaCiudadania == CedulaCiudadania))
            {
                ModelState.AddModelError("CedulaCiudadania", "La cédula de ciudadanía ya está en uso");
                return Page();
            }

            // Verificar si el número telefónico ya está en uso
            if (_context.Usuarios.Any(u => u.NumeroTelefonico == NumeroTelefonico))
            {
                ModelState.AddModelError("NumeroTelefonico", "El número telefónico ya está en uso");
                return Page();
            }

            // Verificar si el correo electrónico es "admin"
            if (CorreoElectronico == "admin@rostrosfelices.com.co")
            {
                ModelState.AddModelError("CorreoElectronico", "No está permitido utilizar este correo electrónico");
                return Page();
            }

            // Lógica para crear el nuevo usuario en la base de datos
            var usuario = new Usuario
            {
                NombreCompleto = NombreCompleto,
                CorreoElectronico = CorreoElectronico,
                TipoSangre = TipoSangre,
                CedulaCiudadania = CedulaCiudadania,
                NumeroTelefonico = NumeroTelefonico,
                Contraseña = Contraseña,
                ConfirmarContraseña = ConfirmarContraseña
            };

            _context.Add(usuario);
            _context.SaveChanges();

            return RedirectToPage("/Usuarios/Index");
        }
    }
}