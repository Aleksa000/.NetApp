using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using USP.Models;
using USP.Services;

namespace USP.Web.Areas.Work.Controllers;

[Area("Work")]
[Authorize]
public class HomeController : Controller
{
    private readonly IWorkService _workService;
    private readonly IMapper _mapper;

    public HomeController(IWorkService workService, IMapper mapper)
    {
        _workService = workService;
        _mapper = mapper;
    }

    /// <summary>
    ///     Index page
    /// </summary>
    /// <returns></returns>
    [Authorize(Policy = "RequireAdminRole")]
    public IActionResult Index(int? startIndex,int? numberOfObject)
    {
        var responseModel = new ResponsePaginationModel
        {
            Works = _workService.PaginationSearch(startIndex, numberOfObject),
            TotalCounts = _workService.TotalCount(),
            StartIndex = startIndex
        };
        return View(responseModel);
    }

    /// <summary>
    ///     Create method - get
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Authorize(Policy = "RequireUserRole")]
    public IActionResult Create()
    {
        return View();
    }

    /// <summary>
    ///     Create method - post
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [Authorize(Policy = "RequireUserRole")]
    [HttpPost]
    public IActionResult Create(WorkModel model)
    {
        if (!ModelState.IsValid)
        {
            TempData["Response"] = false;
            TempData["ResponseMessage"] = "Try again!";
            return View(model);
        }

        _workService.Insert(model);

        TempData["Response"] = true;
        TempData["ResponseMessage"] = "Success!";
        
        return View(model);
    }
}