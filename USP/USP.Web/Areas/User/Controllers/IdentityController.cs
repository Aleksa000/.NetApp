using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using USP.Models;

namespace USP.Web.Areas.User.Controllers;

[Area("User")]
public class IdentityController : Controller
{

    private readonly UserManager<Data.User> _userManager;
    private readonly SignInManager<Data.User> _signInManager;
    private readonly IMapper _mapper;
    public IdentityController(UserManager<Data.User> userManager,IMapper mapper, SignInManager<Data.User> signInManager)
    {
        _userManager = userManager;
        _mapper = mapper;
        _signInManager = signInManager;
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
        
        
         var result = _userManager.CreateAsync(_mapper.Map<Data.User>(model), model.Password);
         
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
        var result = _signInManager.PasswordSignInAsync(model.Email, model.Password,true,false);
        if (result.Result.Succeeded) {
            
        }
        return View();
    }
}
