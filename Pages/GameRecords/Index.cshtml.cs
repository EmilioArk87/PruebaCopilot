using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SnakeGameApp.Data;
using SnakeGameApp.Models;

namespace SnakeGameApp.Pages.GameRecords
{
    public class IndexModel : PageModel
    {
        private readonly GameDbContext _context;

        public IndexModel(GameDbContext context)
        {
            _context = context;
        }

        public IList<GameRecord> GameRecords { get; set; } = default!;

        public async Task OnGetAsync()
        {
            GameRecords = await _context.GameRecords
                .OrderByDescending(g => g.Score)
                .ThenBy(g => g.PlayTimeSeconds)
                .ToListAsync();
        }
    }
}