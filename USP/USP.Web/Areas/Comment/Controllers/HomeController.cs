using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using USP.Models;
using USP.Services;

namespace USP.Web.Areas.Comment.Controllers;
[Area("Comment")]//naziv area preko anotacije
[Authorize]
public class HomeController : Controller
{

    private readonly ICommentService commentService;
    private readonly IMapper mapper;

    public HomeController(ICommentService commentService, IMapper mapper)
    {
        this.commentService = commentService;
        this.mapper = mapper;
    }
    /// <summary>
    /// index page
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return View(commentService.GetAll());
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
    public IActionResult Create(CommentModel model)
    {
        if (!ModelState.IsValid)
        {
            TempData["ResponseMessage"] = "Try again";
            TempData["Response"] = false;
            return View(model);

        }
        commentService.Insert(model);
        TempData["Response"] = true;
        TempData["ResponseMessage"] = "Success";
    
        return View();
    }
}