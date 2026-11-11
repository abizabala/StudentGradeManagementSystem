namespace StudentGradeManagement.API.DTOs;

public class UpdateGradeDto
{
    public int Grade { get; set; }

    public string Semester { get; set; } = string.Empty;

    public string SchoolYear { get; set; } = string.Empty;
}