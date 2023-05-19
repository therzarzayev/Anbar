using AutoMapper;
using EFCore.Models;
using EFCore.Repository;
using EFCore.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace EFCore.Controllers
{
	public class HomeController : Controller
	{
		private readonly IMapper _mapper;
		private readonly IProductRepository _repository;

		public HomeController(IProductRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}
		[Route("/")]
		[Route("/products")]
		public IActionResult Index(string q)
		{
			var pros = _repository.Products;

			var products = _mapper.Map<List<ProductViewModel>>(pros);

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
		[Route("/product")]
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
			return View();
		}
		[HttpPost]
		[Route("/product")]
		public IActionResult Create(ProductViewModel product)
		{
			_repository.CreateProduct(_mapper.Map<Product>(product));
			return RedirectToAction("Index");
		}

		/// <summary>
		/// Update 
		/// </summary>
		[HttpGet]
		[Route("/product/update/{id}")]
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
			var product = _repository.GetById(id);
			return View(_mapper.Map<ProductViewModel>(product));
		}
		[HttpPost]
		[Route("/product/update/{id}")]
		public IActionResult Update(ProductViewModel product)
		{
			_repository.UpdateProduct(_mapper.Map<Product>(product));
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