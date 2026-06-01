/* public class EnrollmentService
{
public EnrollmentRecord ProcessRegistration(Student? student, Course? course)
{
    // Guard clauses
    if (student is null) 
        throw new ArgumentNullException(nameof(student));

    if (course is null)
        throw new ArgumentNullException(nameof(course));

    if (course.EnrolledCount >= course.Capacity)
        throw new InvalidOperationException("Course is full.");

    // Switch expression
    string standing = student.GPA switch
    {
        >= 3.5m => "Honors",
        >= 2.5m => "Good Standing",
        <2.5m => "Academic Warning"
    };

    Console.WriteLine($"{student.Name} is in {standing}.");

    // Return enrollment
    return new EnrollmentRecord(
        student.Id,
        course.Code,
        DateTime.UtcNow
    );
}
}
 */
public class EnrollmentService
{
public EnrollmentRecord ProcessRegistration(Student? student, Course? course)
{
if (student is null)
throw new ArgumentNullException(nameof(student));
if (course is null)
throw new ArgumentNullException(nameof(course));
if (course.EnrolledCount >= course.Capacity)
throw new CapacityReachedException(course.Code);
string standing = student.GPA switch
{
>= 3.5m=>"Honors",
>= 2.5m=>"GoodStanding",
_ =>"Academic Warning"
};
Console.WriteLine($" {student.Name} is in {standing}.");
return new EnrollmentRecord(student.Id, course.Code, DateTime.UtcNow);
}
}