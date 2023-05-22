using BizLand.DAL;
using BizLand.View_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BizLand.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM vm = new HomeVM()
            {
                Slider = await _context.Sliders.FirstOrDefaultAsync(),
                Carts = await _context.Carts.ToListAsync()
            };
            return View(vm);
        }
    }
}
