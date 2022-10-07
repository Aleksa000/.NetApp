using Microsoft.AspNetCore.Mvc;
using USP.Models;
using USP.Services;

namespace USP.Web.Areas.Product.Controllers;
[Area("Product")]//naziv area preko anotacije
public class HomeController : Controller
{

    private readonly IProductService productService;

    public HomeController(IProductService productService)
    {
        this.productService = productService;
    }
    /// <summary>
    /// index page
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        var listOfProducts = productService.GetAll();
        //var insertModel = new ProductModel {Name = "Laptop 1",Price = 1000, Category = "Tehnika"};
        //productService.Insert(insertModel);
        return View(listOfProducts);
    }
}