using BeerApp.Models;
using BeerApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

		public IActionResult Create()
		{
			ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Name");
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken] // espera la informacion del formulario del sitio en cuestion
		public async Task<IActionResult> Create(BeerViewModel model)
		{
			if (ModelState.IsValid)
			{
				var beer = new Beer()
				{
					Name = model.Name,
					BrandId = model.BrandId,
				};
				_context.Add(beer);
				await _context.SaveChangesAsync();

				return RedirectToAction(nameof(Index)); // Retornar al metodo index
			}

			ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Name", model.BrandId);
			return View(model);
		}
	}
}
