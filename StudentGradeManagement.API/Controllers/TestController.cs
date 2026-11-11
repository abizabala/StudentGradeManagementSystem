using Microsoft.AspNetCore.Mvc;
using StudentGradeManagement.API.Data;

namespace StudentGradeManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TestController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var studentCount = _context.Students.Count();

        return Ok(new
        {
            Message = "Database Connected Successfully",
            StudentCount = studentCount
        });
    }
}