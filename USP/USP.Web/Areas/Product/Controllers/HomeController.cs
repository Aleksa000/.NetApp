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
        
        //var insertModel = new ProductModel {Name = "Laptop 1",Price = 1000, Category = "Tehnika"};
        //productService.Insert(insertModel);
        
        return View(productService.GetAll());
    }
/// <summary>
/// Create method - get
/// </summary>
/// <returns></returns>

[HttpGet]
    public IActionResult Create()
{
    return View();

}
/// <summary>
/// Create method - post
/// </summary>
/// <param name="model"></param>
/// <returns></returns>
[HttpPost]
public IActionResult Create(ProductModel model)
{
    if (!ModelState.IsValid)
    {
        TempData["ResponseMessage"] = "Neuspesno dodato";
        TempData["Response"] = false;
        return View(model);

    }
    productService.Insert(model);
    TempData["Response"] = true;
    TempData["ResponseMessage"] = "Uspesno dodato";
    
    return View();
}
}