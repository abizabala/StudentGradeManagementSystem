using Microsoft.AspNetCore.Identity;
using StudentGradeManagement.API.Models;

namespace StudentGradeManagement.API.Seed;

public static class UserSeeder
{
    public static async Task SeedUsersAsync(
        UserManager<ApplicationUser> userManager)
    {
        var facultyEmail = "faculty@test.com";

        var facultyUser =
            await userManager.FindByEmailAsync(facultyEmail);

        if (facultyUser == null)
        {
            facultyUser = new ApplicationUser
            {
                UserName = facultyEmail,
                Email = facultyEmail
            };

            await userManager.CreateAsync(
                facultyUser,
                "Faculty123!");

            await userManager.AddToRoleAsync(
                facultyUser,
                "Faculty");
        }

        var studentEmail = "student@test.com";

        var studentUser =
            await userManager.FindByEmailAsync(studentEmail);

        if (studentUser == null)
        {
            studentUser = new ApplicationUser
            {
                UserName = studentEmail,
                Email = studentEmail,
                StudentId = 1
            };

            await userManager.CreateAsync(
                studentUser,
                "Student123!");

            await userManager.AddToRoleAsync(
                studentUser,
                "Student");
        }
    }
}