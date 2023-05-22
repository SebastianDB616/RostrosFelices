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
        public string Contrase�a { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ConfirmarContrase�a { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Contrase�a = string.Empty;
                ConfirmarContrase�a = string.Empty;
                return Page();
            }

            if (Contrase�a != ConfirmarContrase�a)
            {
                ModelState.AddModelError("ConfirmarContrase�a", "Las contrase�as no coinciden");
                return Page();
            }

            // Verificar si el correo electr�nico ya est� en uso
            if (_context.Usuarios.Any(u => u.NombreCompleto == NombreCompleto))
            {
                ModelState.AddModelError("NombreCompleto", "El nombre completo ya est� en uso");
                return Page();
            }

            // Verificar si el nombre completo ya est� en uso
            if (_context.Usuarios.Any(u => u.CorreoElectronico == CorreoElectronico))
            {
                ModelState.AddModelError("CorreoElectronico", "El correo electr�nico ya est� en uso");
                return Page();
            }

            // Verificar si la c�dula de ciudadan�a ya est� en uso
            if (_context.Usuarios.Any(u => u.CedulaCiudadania == CedulaCiudadania))
            {
                ModelState.AddModelError("CedulaCiudadania", "La c�dula de ciudadan�a ya est� en uso");
                return Page();
            }

            // Verificar si el n�mero telef�nico ya est� en uso
            if (_context.Usuarios.Any(u => u.NumeroTelefonico == NumeroTelefonico))
            {
                ModelState.AddModelError("NumeroTelefonico", "El n�mero telef�nico ya est� en uso");
                return Page();
            }

            // Verificar si el correo electr�nico es "admin"
            if (CorreoElectronico == "admin@rostrosfelices.com.co")
            {
                ModelState.AddModelError("CorreoElectronico", "No est� permitido utilizar este correo electr�nico");
                return Page();
            }

            // L�gica para crear el nuevo usuario en la base de datos
            var usuario = new Usuario
            {
                NombreCompleto = NombreCompleto,
                CorreoElectronico = CorreoElectronico,
                TipoSangre = TipoSangre,
                CedulaCiudadania = CedulaCiudadania,
                NumeroTelefonico = NumeroTelefonico,
                Contrase�a = Contrase�a,
                ConfirmarContrase�a = ConfirmarContrase�a
            };

            _context.Add(usuario);
            _context.SaveChanges();

            return RedirectToPage("/Usuarios/Index");
        }
    }
}