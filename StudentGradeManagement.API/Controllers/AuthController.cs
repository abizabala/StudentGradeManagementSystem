using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentGradeManagement.API.DTOs;
using StudentGradeManagement.API.Models;

namespace StudentGradeManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AuthController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var user =
            await _userManager.FindByEmailAsync(dto.Email);

        if (user == null)
        {
            return Unauthorized("Invalid credentials.");
        }

        var result =
    await _signInManager.PasswordSignInAsync(
        user.UserName!,
        dto.Password,
        true,
        false);

        if (!result.Succeeded)
        {
            return Unauthorized("Invalid credentials.");
        }

        var roles =
            await _userManager.GetRolesAsync(user);
        return Ok(new
        {
            user.Email,
            Roles = roles
        });
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();

        return Ok("Logged out.");
    }
}