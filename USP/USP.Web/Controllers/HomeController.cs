using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using USP.Web.Models;

namespace USP.Web.Controllers;

public class HomeController : Controller//:nasledjivanje metode 
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
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
        var userModel = new UserModel//prepoznaje sam tip podataka o kome se radi
        {
            Id = 1,
            UserName = "Aleksa1",
            FirstName = "Aleksa",
            LastName = "Grbic",
            Email = "aleksa.grbic00@gmail.com",
        };
        var userModel2 = new UserModel//prepoznaje sam tip podataka o kome se radi
        {
            Id = 2,
            UserName = "Aleksa2",
            FirstName = "Aleksa",
            LastName = "Savic",
            Email = "aleksa.savic00@gmail.com",
        };

        var listOfUserModel = new List<UserModel>();
        
        listOfUserModel.Add(userModel);
        listOfUserModel.Add(userModel2);
        
        return View(listOfUserModel);//vraca neki html
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}