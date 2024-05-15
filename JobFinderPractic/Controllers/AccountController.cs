using JobFinderPractic.DataAccess.Data;
using JobFinderPractic.Domain.Entities.Abstracts;
using JobFinderPractic.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using NuGet.Packaging.Signing;

namespace JobFinderPractic.Controllers;

public class AccountController : Controller
{
	private readonly AppDbContext _context;
	private readonly UserManager<AppUser> _userManager;
	private readonly SignInManager<AppUser> _signInManager;

	public AccountController(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
	{
		_context = context;
		_userManager = userManager;
		_signInManager = signInManager;
	}

	// Login
	[HttpGet]
	public IActionResult Login()
	{
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Login(LoginVM loginVM)
	{
		var getUser = await _userManager.FindByEmailAsync(loginVM.Email);

		if (getUser != null)
		{
			var result = await _userManager.CheckPasswordAsync(getUser, loginVM.Password);
			if (result)
				await _signInManager.SignInAsync(getUser, true);
		}
		return Redirect("/Home/Index");
	}
	// Register
	[HttpGet]
	public IActionResult Register()
	{
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Register(RegisterVm registerVm)
	{
		if (!ModelState.IsValid)
		{
			return View(registerVm);
		}

		var newUser = new AppUser()
		{
			UserName = registerVm.FullName,
			Email = registerVm.Email

		};
		var createdIdentityResult = await _userManager.CreateAsync(newUser, registerVm.Password!);
		if (createdIdentityResult.Succeeded)
		{
			await _userManager.AddToRoleAsync(newUser, "Employer");
			return Redirect("/AllUsers/Home/Index");
		}
		else
			foreach (var error in createdIdentityResult.Errors)
				ModelState.AddModelError("All", error.Description);

		return View(registerVm);

	}

	// LogOut
	[HttpGet]
	[Authorize]
	public async Task<IActionResult> LogOut()
	{
		await _signInManager.SignOutAsync();
		return RedirectToAction("Index", "Home");
	}

	// Access Denied
	[HttpGet]
	public IActionResult AccessDenied()
	{
		return View();
	}
}
