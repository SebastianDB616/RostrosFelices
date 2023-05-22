using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RostrosFelices.Data;
using RostrosFelices.Models;

namespace RostrosFelices.Pages.Servicios
{
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditarModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Servicio Servicio { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Servicio = _context.Servicios.FirstOrDefault(s => s.Id == id);

            if (Servicio == null)
            {
                return NotFound();
            }

            ViewData["Clientes"] = new SelectList(_context.Clientes.ToList(), "Id", "NombreCompleto");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ViewData["Clientes"] = new SelectList(_context.Clientes.ToList(), "Id", "NombreCompleto");
                return Page();
            }

            _context.Attach(Servicio).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}