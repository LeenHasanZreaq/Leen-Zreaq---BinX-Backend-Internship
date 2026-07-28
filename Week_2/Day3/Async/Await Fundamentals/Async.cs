using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Application Started");

        Task<string> studentTask = GetStudentNameAsync();
        Task<int> gradeTask = GetStudentGradeAsync();

        string name = await studentTask;
        int grade = await gradeTask;

        Console.WriteLine($"Student: {name}");
        Console.WriteLine($"Grade: {grade}");

        Console.WriteLine("Application Finished");
    }

    static async Task<string> GetStudentNameAsync()
    {
        await Task.Delay(2000);
        return "Leen";
    }

    static async Task<int> GetStudentGradeAsync()
    {
        await Task.Delay(3000);
        return 95;
    }
}