using Microsoft.AspNetCore.Mvc;

namespace USP.Web.Areas.Product.Controllers;
[Area("Product")]//naziv area preko anotacije
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}