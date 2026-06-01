public record EnrollmentRecord(string StudentId, string CourseCode, DateTime EnrolledAt);

public class Course
{
public required string Code { get; init; }
public required string Title
{
get;
set => field = !string.IsNullOrWhiteSpace(value)
? value
: throw new ArgumentException("Title cannot be empty or whitespace.", nameof(value));
}
// C# 14Auto-property validation using 'field'
public int Capacity
{
get;
set => field = value > 0
? value
: throw new ArgumentOutOfRangeException(nameof(value), "System constraint: Capacity must begreater than zero.");
}
public int EnrolledCount { get; set; }
}

public class Student
{
public required string Id { get; init; }
public required string Name
{
get;
set => field = !string.IsNullOrWhiteSpace(value)
? value
: throw new ArgumentException("Name cannot be empty or whitespace.", nameof(value));
}
public int Age
{
get;
set => field = value is >= 16 and <= 100
? value
: throw new ArgumentOutOfRangeException(nameof(value), "Age must be between 16 and 100.");
}
public decimal GPA
{
get;
set => field = value is >= 0.0m and <= 4.0m
? value
: throw new ArgumentOutOfRangeException(nameof(value), "GPA must be between 0.0and 4.0.");
}
}

public interface IGradable{
string Title { get; }
decimal CalculateGrade();
}

public class Quiz : IGradable
{
public required string Title { get; init; }
public required int CorrectAnswers { get; init; }
public required int TotalQuestions { get; init; }
public decimal CalculateGrade()
{
if (TotalQuestions == 0) return 0m;
return (decimal)CorrectAnswers / TotalQuestions * 100m;
}
}
public class LabAssignment : IGradable
{
public required string Title { get; init; }
public required decimal FunctionalityScore { get; init; }
public required decimal CodeQualityScore { get; init; }
public decimal CalculateGrade()
{
// 70% functionality, 30% code quality
return (FunctionalityScore * 0.7m) + (CodeQualityScore * 0.3m);
}
}
/* 
var leaderboard = students
    // TODO1: Extract students where GPA is >= 3.5m
    .Where(s => s.GPA >= 3.5m)

    // TODO2: Sort the remaining students by GPA descending
    .OrderByDescending(s => s.GPA)

    // TODO3: Project the result so we only keep the 'Name' string
    .Select(s => s.Name)

    // TODO4: Materialize the lazy query into a concrete List
    .ToList();

Console.WriteLine($"Found {leaderboard.Count} Honors Students:");

foreach (var name in leaderboard)
{
    Console.WriteLine($"- {name}");
}
// TODO5: Use LINQ to calculate the average GPA across all students.
// Format it to 2 decimal places using :F2.

decimal averageGpa = students.Average(s => s.GPA);

Console.WriteLine($"\nClass Average GPA: {averageGpa:F2}");


// Step 4 Group by Academic Standing

// TODO6: Use .GroupBy with a switch expression to classify each student.

var standingGroups = students.GroupBy(s => s.GPA switch
{
    >= 3.5m => "Honors",
    >= 2.5m => "Good Standing",
    >= 2.0m => "Probation",
    _ => "Academic Warning"
});

Console.WriteLine("\n--- Academic Standing Report ---");

foreach (var group in standingGroups)
{
    Console.WriteLine($"\n{group.Key} ({group.Count()}):");

    foreach (var s in group)
    {
        Console.WriteLine($" {s.Name} GPA: {s.GPA}");
    }
}


// Step 5 Collection Expressions with Spread

// TODO7: Use the spread operator (..) to merge two arrays and append a value.

string[] backendCourses = ["C#", "ASP.NET Core"];
string[] frontendCourses = ["TypeScript", "Angular"];

string[] allCourses =
[
    ..backendCourses,
    ..frontendCourses,
    "SQL"
];

Console.WriteLine($"\nFull curriculum: {string.Join(", ", allCourses)}");*/