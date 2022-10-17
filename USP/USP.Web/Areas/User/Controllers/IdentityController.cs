using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using USP.Models;
using USP.Web.Controllers;

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
    public async Task<IActionResult> Registration(RegistrationModel model)
    {
        if (!ModelState.IsValid)
        {
            TempData["Response"] = false;
            TempData["ResponseMessage"] = "Try again";
            return View(model);
        }
        
        
        var result = await _userManager.CreateAsync(_mapper.Map<Data.User>(model), model.Password);
         
         
        var errorString = "";
         
        if (!result.Succeeded)
        {
            if (result.Errors is { } && result.Errors.Any())
            {
                foreach (var identityError in result.Errors)
                {
                    errorString += "\n" + identityError.Description;
                }
            }
            TempData["Response"] = false;
            TempData["ResponseMessage"] = errorString;
            return View(model);
        }
        
        var user = await  _userManager.FindByNameAsync(model.Email);//izvrsena pretraga

        if (user is null) return View();//korisnik nije pronadjen
        var checkRolesResult = await _userManager.IsInRoleAsync(user, "User");//provera role

        if (checkRolesResult) return View();
        var addToRolesResult = await _userManager.AddToRoleAsync(user, "User");//ukoliko nema rolu dodaje mu se rola

        if (!addToRolesResult.Succeeded) return View();
        TempData["Response"] = true;
        TempData["ResponseMessage"] = "Succeeded";
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
    /// logout method
    /// </summary>
    /// <returns></returns>
    public IActionResult LogOut()
    {
        _signInManager.SignOutAsync();
        return RedirectToAction("Index","Home", new {area = ""});
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
