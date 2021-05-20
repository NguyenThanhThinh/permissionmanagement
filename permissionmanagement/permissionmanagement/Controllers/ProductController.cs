using Microsoft.AspNetCore.Mvc;

namespace permissionmanagement.Controllers
{
	public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
