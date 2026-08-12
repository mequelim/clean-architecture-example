using CleanArchitectureMvc.Domain.Account;
using CleanArchitectureMvc.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureMvc.WebUI.Controllers;

public class AccountController : Controller
{
    private readonly IAuthenticate _authentication;

    public AccountController(IAuthenticate authentication) => _authentication = authentication;

    //* Methods...
    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        bool result = await _authentication.RegisterUser(model.Email, model.Password);

        if(result)
        {
            return Redirect("/");
        } else
        {
            ModelState.AddModelError(string.Empty, "Registration failed! Please try again...");
            return View(model);
        }
    }

    [HttpGet]
    public IActionResult Login(string returnUrl) => View(new LoginViewModel() { ReturnUrl = returnUrl });

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        var result = await Task.FromResult(Ok("Registration successful!"));

        if(result is null)
        {
            if(string.IsNullOrEmpty(model.ReturnUrl)) return RedirectToAction("Index", "Home");

            return Redirect(model.ReturnUrl);
        } else
        {
            ModelState.AddModelError(string.Empty, "Invalid login attempt!");
            return View(model);
        }
    }

    public async Task<IActionResult> Logout()
    {
        await _authentication.Logout();
        return Redirect("/Account/Login");
    }
}