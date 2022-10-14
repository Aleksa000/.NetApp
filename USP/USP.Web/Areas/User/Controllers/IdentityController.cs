using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using USP.Models;

namespace USP.Web.Areas.User.Controllers;

[Area("User")]
public class IdentityController : Controller
{

    private readonly UserManager<Data.User> userManager;
    private readonly SignInManager<Data.User> signInManager;
    private readonly IMapper mapper;
    public IdentityController(UserManager<Data.User> userManager, SignInManager<Data.User> signInManager, IMapper mapper)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.mapper = mapper;
    }
    
    /// <summary>
    /// registration http get
    /// </summary>
    /// <returns></returns>
    public IActionResult Registration()
    {
        return View();
    }
   
    /// <summary>
    /// registration http post
    /// </summary>
    /// <returns></returns>
    
    [HttpPost]
    public IActionResult Registration(RegistrationModel model)
    {
        
        
        userManager.CreateAsync(mapper.Map<Data.User>(model), model.Password);
        return View();
    }
    
    /// <summary>
    /// login http get
    /// </summary>
    /// <returns></returns>
    
    public IActionResult Login()
    {
        return View();
    }

    /// <summary>
    /// login http post
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Login(LoginModel model)
    {
        return View();
    }
}
