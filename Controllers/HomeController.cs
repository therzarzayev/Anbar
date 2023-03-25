using EFCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace EFCore.Controllers
{
	public class HomeController : Controller
	{
		private IProductRepository _repository;

		public HomeController(IProductRepository repository)
		{
			_repository = repository;
		}


		public IActionResult Index(string q)
		{
			var products = _repository.Products;

			if (string.IsNullOrEmpty(q))
			{
				return View(products);
			}
			else
			{
				return View(products.Where(x => x.Name.ToLower().Contains(q.ToLower())));
			}
		}

		/// <summary>
		/// Create 
		/// </summary>
		[HttpGet]
		public IActionResult Create()
		{
			ViewBag.Categories = new SelectList(new List<string>
			{
				"Geyim",
				"Aksesuar",
				"Oyuncaq",
				"Makyaj",
				"Kompüter hissələri",
				"Yaddaş qurğuları"
			});
			ViewBag.States = new SelectList(new List<string>
			{
				"Xarici anbarda",
				"Bəyan gözlənilir",
				"Gömrük yoxlanışı",
				"Çeşidlənir",
				"Təhvil verildi"
			});
			return View();
		}
		[HttpPost]
		public IActionResult Create(Product product)
		{
			_repository.CreateProduct(product);
			return RedirectToAction("Index");
		}

		/// <summary>
		/// Update 
		/// </summary>
		[HttpGet]
		public IActionResult Update(int id)
		{
			ViewBag.Categories = new SelectList(new List<string>
			{
				"Geyim",
				"Aksesuar",
				"Oyuncaq",
				"Makyaj",
				"Kompüter hissələri",
				"Yaddaş qurğuları"
			});
			ViewBag.States = new SelectList(new List<string>
			{
				"Xarici anbarda",
				"Bəyan gözlənilir",
				"Gömrük yoxlanışı",
				"Çeşidlənir",
				"Təhvil verildi"
			});
			return View(_repository.GetById(id));
		}
		[HttpPost]
		public IActionResult Update(Product product)
		{
			_repository.UpdateProduct(product);
			return RedirectToAction("Index");
		}

		/// <summary>
		/// Delete 
		/// </summary>
		[HttpGet]
		public IActionResult Delete(int id)
		{
			_repository.DeleteProduct(id);
			return RedirectToAction("Index");
		}
	}
}