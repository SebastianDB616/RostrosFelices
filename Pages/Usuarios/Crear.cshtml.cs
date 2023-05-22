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