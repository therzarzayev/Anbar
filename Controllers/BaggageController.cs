using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controllers
{
	public class BaggageController : Controller
	{
		[Route("/baggage")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
