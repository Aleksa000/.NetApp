using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using USP.Models;
using USP.Services;

namespace USP.Web.Areas.Comment.Controllers;
[Area("Comment")]//naziv area preko anotacije

public class HomeController : Controller
{

    private readonly ICommentService _commentService;
    private readonly IMapper _mapper;

    public HomeController(ICommentService commentService, IMapper mapper)
    {
        _commentService = commentService;
        _mapper = mapper;
    }
    /// <summary>
    /// index page
    /// </summary>
    /// <returns></returns>
   [Authorize(Policy = "RequireAdminRole")]
    public IActionResult Index(int? startIndex,int? numberOfObject)
    {
        
        var responseModel = new ResponsePaginationModel
        {
            Comments = _commentService.PaginationSearch(startIndex, numberOfObject),
            TotalCounts = _commentService.TotalCount(),
            StartIndex = startIndex
        };
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

    return View(new CommentModel{Categories = _mapper.Map<List<SelectListItem>>(categories),Types =  _mapper.Map<List<SelectListItem>>(types)});

}

/// <summary>
/// Create method - post
/// </summary>
/// <param name="model"></param>
/// <returns></returns>
[Authorize(Policy = "RequireUserRole")]
[HttpPost]
public IActionResult Create(CommentModel model)
{
    if (!ModelState.IsValid)
    {
        TempData["ResponseMessage"] = "Try again";
        TempData["Response"] = false;
        return View(model);

    }
    _commentService.Insert(model);
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


    model.Categories = _mapper.Map<List<SelectListItem>>(categories);
    model.Types = _mapper.Map<List<SelectListItem>>(types);
    
    return View(model);
}

}