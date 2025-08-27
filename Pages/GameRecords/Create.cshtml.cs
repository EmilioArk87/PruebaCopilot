using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SnakeGameApp.Data;
using SnakeGameApp.Models;

namespace SnakeGameApp.Pages.GameRecords
{
    public class CreateModel : PageModel
    {
        private readonly GameDbContext _context;

        public CreateModel(GameDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public GameRecord GameRecord { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            GameRecord.CreatedAt = DateTime.Now;
            _context.GameRecords.Add(GameRecord);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}