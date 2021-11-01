using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using blog.Data;
namespace blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlogDbContext _context;

        public HomeController(BlogDbContext context)
        {
            _context = context;
        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
            return View(await _context.BlogCategoryUsers.ToListAsync());
        }

        // GET: Home/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.BlogCategoryUsers.FirstOrDefaultAsync(m => m.BlogId == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }
    }
}
