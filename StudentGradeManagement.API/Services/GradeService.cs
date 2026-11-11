namespace StudentGradeManagement.API.Services;

public static class GradeService
{
    public static string GetRemarks(int grade)
    {
        if (grade >= 95)
            return "CMS";

        if (grade >= 90)
            return "SP";

        if (grade >= 85)
            return "SAP";

        if (grade >= 80)
            return "GP";

        if (grade >= 75)
            return "EP";

        return "BEP/FAILED";
    }
}