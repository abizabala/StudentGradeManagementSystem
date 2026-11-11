using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentGradeManagement.API.Data;
using StudentGradeManagement.API.Models;

namespace StudentGradeManagement.API.Controllers;

[ApiController]
[Route("api/student")]
[Authorize(Roles = "Student")]
public class StudentApiController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public StudentApiController(
        ApplicationDbContext context,
        UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpGet("grades")]
    public async Task<IActionResult> GetMyGrades()
    {
        var email = User.Identity?.Name;

        if (email == null)
            return Unauthorized();

        var user =
            await _userManager.FindByNameAsync(email);

        if (user == null)
            return Unauthorized();

        var grades =
            await _context.StudentGrades
                .Where(g => g.StudentId == user.StudentId)
                .ToListAsync();

        return Ok(grades);
    }
}