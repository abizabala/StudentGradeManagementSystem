namespace StudentGradeManagement.API.DTOs;

public class CreateGradeDto
{
    public int StudentId { get; set; }

    public string SubjectCode { get; set; } = string.Empty;

    public string SubjectName { get; set; } = string.Empty;

    public int FacultyId { get; set; }

    public int Grade { get; set; }

    public string Semester { get; set; } = string.Empty;

    public string SchoolYear { get; set; } = string.Empty;
}