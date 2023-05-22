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

            var cliente = _context.Clientes.Find(Cliente.Id);

            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente); // Eliminar el cliente
            _context.SaveChanges(); // Guardar los cambios en la base de datos

            return RedirectToPage("./Index"); // Redirigir a la página de índice
        }
    }
}