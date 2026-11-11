using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentGradeManagement.API.Data;
using StudentGradeManagement.API.DTOs;
using StudentGradeManagement.API.Models;
using StudentGradeManagement.API.Services;
using Microsoft.AspNetCore.Authorization;

namespace StudentGradeManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GradesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public GradesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetGrades()
    {
        var grades = await _context.StudentGrades.ToListAsync();

        return Ok(grades);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGrade(int id)
    {
        var grade = await _context.StudentGrades.FindAsync(id);

        if (grade == null)
            return NotFound();

        return Ok(grade);
    }

    [Authorize(Roles = "Faculty")]
    [HttpPost]
    public async Task<IActionResult> CreateGrade(CreateGradeDto dto)
    {
        if (dto.Grade < 0 || dto.Grade > 100)
        {
            return BadRequest("Grade must be between 0 and 100.");
        }

        var grade = new StudentGrade
        {
            StudentId = dto.StudentId,
            SubjectCode = dto.SubjectCode,
            SubjectName = dto.SubjectName,
            FacultyId = dto.FacultyId,
            Grade = dto.Grade,
            Remarks = GradeService.GetRemarks(dto.Grade),
            Semester = dto.Semester,
            SchoolYear = dto.SchoolYear,
            DatePosted = DateTime.UtcNow
        };

        _context.StudentGrades.Add(grade);

        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetGrade),
            new { id = grade.GradeId },
            grade);
    }

    [Authorize(Roles = "Faculty")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGrade(
    int id,
    UpdateGradeDto dto)
    {
        var grade = await _context.StudentGrades.FindAsync(id);

        if (grade == null)
            return NotFound();

        if (dto.Grade < 0 || dto.Grade > 100)
            return BadRequest("Grade must be between 0 and 100.");

        grade.Grade = dto.Grade;

        grade.Remarks = GradeService.GetRemarks(dto.Grade);

        grade.Semester = dto.Semester;

        grade.SchoolYear = dto.SchoolYear;

        grade.DateModified = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return Ok(grade);
    }

    [Authorize(Roles = "Faculty")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGrade(int id)
    {
        var grade = await _context.StudentGrades.FindAsync(id);

        if (grade == null)
            return NotFound();

        _context.StudentGrades.Remove(grade);

        await _context.SaveChangesAsync();

        return NoContent();
    }


}