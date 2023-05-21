using BeerApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeerApp.Controllers
{
	public class BeerController : Controller
	{
		private readonly BeerAppContext _context;

        public BeerController(BeerAppContext context)
        {
			_context = context;
        }

        public async Task<IActionResult> Index()
		{
			var beers = _context.Beers.Include(brand => brand.Brand);
			return View(await beers.ToListAsync());
		}


	}
}
