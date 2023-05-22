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
        public string Contrase�a { get; set; }

        [BindProperty]
        public string ConfirmarContrase�a { get; set; }

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

            if (Contrase�a != ConfirmarContrase�a)
            {
                ModelState.AddModelError("ConfirmarContrase�a", "Las contrase�as no coinciden");
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