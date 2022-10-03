using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using USP.Models;
using USP.Models;
using USP.Services;

namespace USP.Web.Controllers;

public class HomeController : Controller//:nasledjivanje metode 
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUserService _userService;

    public HomeController(ILogger<HomeController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    public IActionResult Index()
    {
        
        return View();//vraca neki html
    }
    /// <summary>
    /// get all users
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Users()
    {
        return View(_userService.GetAll());//vraca neki html
    }
    /// <summary>
    /// Create user - post metod
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public IActionResult CreateUser(UserModel model)
    {
        return View();
    }
    /// <summary>
    /// Create user get metodom
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult CreateUser()
    {
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }
}