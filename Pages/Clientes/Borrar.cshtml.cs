using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RostrosFelices.Data;
using RostrosFelices.Models;

namespace RostrosFelices.Pages.Clientes
{
    public class BorrarModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public BorrarModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cliente Cliente { get; set; }

        public IActionResult OnGet(int id)
        {
            Cliente = _context.Clientes.Find(id);

            if (Cliente == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Clientes.Remove(Cliente);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}