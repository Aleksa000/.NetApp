using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Policy = "RequireAdminRole")]
    public IActionResult Index(int? startIndex,int? numberOfObject)
    {
        
        //var insertModel = new ProductModel {Name = "Laptop 1",Price = 1000, Category = "Tehnika"};
        //productService.Insert(insertModel);

        var responseModel = new ResponsePaginationModel();
        responseModel.Products = productService.PaginationSearch(startIndex, numberOfObject);
        responseModel.TotalCounts = productService.TotalCount();
        responseModel.StartIndex = startIndex;
        return View(responseModel);
    }
/// <summary>
/// Create method - get
/// </summary>
/// <returns></returns>
[Authorize(Policy = "RequireUserRole")]
[HttpGet]
    public IActionResult Create()
{
    var category1 = new CategoryModel { Id = "1", Name = "Silan blokovi" };
    var category2 = new CategoryModel { Id = "2", Name = "Akumulator" };
    var category3 = new CategoryModel { Id = "3", Name = "Motorno ulje" };
    var category4 = new CategoryModel { Id = "4", Name = "Diskovi i plocice" };
    var category5 = new CategoryModel { Id = "5", Name = "Ulje za kocnice" };
    
    var categories = new List<CategoryModel>
    {
        category1,
        category2,
        category3,
        category4,
        category5
    };
    var type1 = new TypeModel { Id = "589", Type = "Beznin" };
    var type2 = new TypeModel { Id = "745", Type = "Dizel" };
    
    var types = new List<TypeModel>
    {
        type1,
        type2
        
    };

    return View(new ProductModel{Categories = mapper.Map<List<SelectListItem>>(categories),Types =  mapper.Map<List<SelectListItem>>(types)});

}


/// <summary>
/// Product update
/// </summary>
/// <param name="productId"></param>
/// <returns></returns>
[Authorize(Policy = "RequireAdminRole")]
    public IActionResult Update(string productId)
{
    var category1 = new CategoryModel { Id = "1", Name = "Silan blokovi" };
    var category2 = new CategoryModel { Id = "2", Name = "Akumulator" };
    var category3 = new CategoryModel { Id = "3", Name = "Motorno ulje" };
    var category4 = new CategoryModel { Id = "4", Name = "Diskovi i plocice" };
    var category5 = new CategoryModel { Id = "5", Name = "Ulje za kocnice" };
    var categories = new List<CategoryModel>
    {
        category1,
        category2,
        category3,
        category4,
        category5
    };
    var type1 = new TypeModel { Id = "589", Type = "Beznin" };
    var type2 = new TypeModel { Id = "745", Type = "Dizel" };
    
    var types = new List<TypeModel>
    {
        type1,
        type2
        
    };


    var model = productService.GetOne(productId);
    model.Categories = mapper.Map<List<SelectListItem>>(categories);
    model.Types = mapper.Map<List<SelectListItem>>(types);
    return View(model);

}
/// <summary>
/// Delete method
/// </summary>
/// <param name="productId"></param>
/// <returns></returns>
[Authorize(Policy = "RequireAdminRole")]
public IActionResult Delete(string productId)
{
    
    var model = productService.GetOne(productId);
    productService.Delete(model);
    TempData["Response"] = true;
    TempData["ResponseMessage"] = "Success deleted";
    return RedirectToAction("Index");
    

}
/// <summary>
/// Update post method
/// </summary>
/// <param name="model"></param>
/// <returns></returns>
[Authorize(Policy = "RequireAdminRole")]
[HttpPost]
public IActionResult Update(ProductModel model)
{
    if (!ModelState.IsValid)
    {
        TempData["ResponseMessage"] = "Try again";
        TempData["Response"] = false;
        return View(model);

    }
    productService.Update(model);
    TempData["Response"] = true;
    TempData["ResponseMessage"] = "Success updated";
    
    var category1 = new CategoryModel { Id = "1", Name = "Silan blokovi" };
    var category2 = new CategoryModel { Id = "2", Name = "Akumulator" };
    var category3 = new CategoryModel { Id = "3", Name = "Motorne ulje" };
    var category4 = new CategoryModel { Id = "4", Name = "Diskovi i plocice" };
    var category5 = new CategoryModel { Id = "5", Name = "Ulje za kocnice" };
    var categories = new List<CategoryModel>();
    categories.Add(category1);
    categories.Add(category2);
    categories.Add(category3);
    categories.Add(category4);
    categories.Add(category5);
    
    var type1 = new TypeModel { Id = "589", Type = "Beznin" };
    var type2 = new TypeModel { Id = "745", Type = "Dizel" };
    
    var types = new List<TypeModel>
    {
        type1,
        type2
        
    };
    
    

    model.Categories = mapper.Map<List<SelectListItem>>(categories);
    model.Types = mapper.Map<List<SelectListItem>>(types);
    
    return View(model);
}
/// <summary>
/// Create method - post
/// </summary>
/// <param name="model"></param>
/// <returns></returns>
[Authorize(Policy = "RequireUserRole")]
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
    
    var category1 = new CategoryModel { Id = "1", Name = "Silan blokovi" };
    var category2 = new CategoryModel { Id = "2", Name = "Akumulator" };
    var category3 = new CategoryModel { Id = "3", Name = "Motorno ulje" };
    var category4 = new CategoryModel { Id = "4", Name = "Diskovi i plocice" };
    var category5 = new CategoryModel { Id = "5", Name = "Ulje za kocnice" };
    var categories = new List<CategoryModel>
    {
        category1,
        category2,
        category3,
        category4,
        category5
    };
    var type1 = new TypeModel { Id = "589", Type = "Beznin" };
    var type2 = new TypeModel { Id = "745", Type = "Dizel" };
    
    var types = new List<TypeModel>
    {
        type1,
        type2
        
    };


    model.Categories = mapper.Map<List<SelectListItem>>(categories);
    model.Types = mapper.Map<List<SelectListItem>>(types);
    
    return View(model);
}

}