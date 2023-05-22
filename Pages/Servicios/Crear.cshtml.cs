using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RostrosFelices.Data;
using RostrosFelices.Models;

namespace RostrosFelices.Pages.Servicios
{
    public class CrearModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CrearModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["Clientes"] = new SelectList(_context.Clientes.ToList(), "Id", "NombreCompleto");
            return Page();
        }

        [BindProperty]
        public Servicio Servicio { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ViewData["Clientes"] = new SelectList(_context.Clientes.ToList(), "Id", "NombreCompleto");
                return Page();
            }

            _context.Update(Servicio);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}