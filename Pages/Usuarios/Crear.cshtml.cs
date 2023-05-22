using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        [BindProperty]
        public string Contraseña { get; set; }

        [BindProperty]
        public string ConfirmarContraseña { get; set; }

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