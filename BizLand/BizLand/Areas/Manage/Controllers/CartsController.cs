using BizLand.DAL;
using BizLand.Models;
using BizLand.View_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BizLand.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CartsController : Controller
    {
        private readonly AppDbContext _context;

        public CartsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int page = 1, int take=1 )
        {
            var cartItems= await _context.Carts.Skip((page-1)*take).Take(take).ToListAsync();
            PaginateVM<Cart> paginateVM = new PaginateVM<Cart>()
            {
                Items = cartItems,
                CurrentPage = page,
                Take = take,
                PageCount = GetPageCount(take)

            };
            return View( paginateVM );
        }

        private int GetPageCount(int take)
        {
            var PageCount= _context.Carts.Count();
            return (int)Math.Ceiling(((decimal)(PageCount / take)));
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cart cart)
        {
            if (!ModelState.IsValid) { return View(); }
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _context.Carts.FirstOrDefaultAsync(x => x.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult>Edit(Cart cart)
        {
            if (!ModelState.IsValid) { return View(); }
            Cart ?exists= await _context.Carts.FirstOrDefaultAsync(x=>x.Id == cart.Id);
            if(exists == null) { ModelState.AddModelError("Cart", "Cart not found"); return View(); }
            exists.Title= cart.Title;
            exists.Description= cart.Description;
            exists.Icon= cart.Icon;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));            
        }

        [HttpPost]
        public async Task<IActionResult>Delete(int id)
        {
            if (!ModelState.IsValid) { return View(); }
            Cart? exists = await _context.Carts.FirstOrDefaultAsync(x => x.Id == id);
            if (exists == null) { ModelState.AddModelError("Cart", "Cart not found"); return View(); }
            _context.Carts.Remove(exists);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
