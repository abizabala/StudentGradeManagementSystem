using Microsoft.AspNetCore.Mvc;

namespace StudentGradeManagement.Web.Controllers;

public class StudentController : Controller
{
    public IActionResult Dashboard()
    {
        return View();
    }
}