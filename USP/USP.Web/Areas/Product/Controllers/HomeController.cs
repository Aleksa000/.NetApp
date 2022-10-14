using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using USP.Data;
using USP.Models;
using USP.Services;

namespace USP.Web.Areas.Product.Controllers;
[Area("Product")]//naziv area preko anotacije
public class HomeController : Controller
{

    private readonly IProductService productService;
    private readonly IMapper mapper;

    public HomeController(IProductService productService, IMapper mapper)
    {
        this.productService = productService;
        this.mapper = mapper;
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
    var category1 = new CategoryModel { Id = "12345", Name = "Tehnika" };
    var category2 = new CategoryModel { Id = "123456", Name = "Tehnika1" };
    var categories = new List<CategoryModel>();
    categories.Add(category1);
    categories.Add(category2);
   
    return View(new ProductModel{Categories = mapper.Map<List<SelectListItem>>(categories)});

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
        TempData["ResponseMessage"] = "Try again";
        TempData["Response"] = false;
        return View(model);

    }
    productService.Insert(model);
    TempData["Response"] = true;
    TempData["ResponseMessage"] = "Success";
    
    var category1 = new CategoryModel { Id = "12345", Name = "Tehnika" };
    var category2 = new CategoryModel { Id = "123456", Name = "Tehnika1" };
    var categories = new List<CategoryModel>();
    categories.Add(category1);
    categories.Add(category2);

    model.Categories = mapper.Map<List<SelectListItem>>(categories);
    
    return View(model);
}
}