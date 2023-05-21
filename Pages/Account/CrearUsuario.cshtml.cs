using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RostrosFelices.Data;
using RostrosFelices.Models;
using System.Threading.Tasks;

namespace RostrosFelices.Pages.Account
{
    public class CreateUsuarioModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateUsuarioModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            if (!User.Identity.IsAuthenticated || User.Identity.Name != "admin@rostrosfelices.com.co")
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }

        [BindProperty]
        public Usuario Usuario { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Usuarios.Add(Usuario);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}