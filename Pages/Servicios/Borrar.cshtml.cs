using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RostrosFelices.Data;
using RostrosFelices.Models;

namespace RostrosFelices.Pages.Servicios
{
    public class BorrarModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public BorrarModel(ApplicationDbContext context)
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

            return Page();
        }

        public IActionResult OnPost()
        {
            var servicio = _context.Servicios.Find(Servicio.Id);

            if (servicio == null)
            {
                return NotFound();
            }

            _context.Servicios.Remove(servicio);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}