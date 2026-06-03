/* public class EnrollmentService{
    
    public EnrollmentRecord ProcessRegistration(Student? student, Course? course)
    { 
        if (student is null)
        {
            throw new ArgumentNullException(nameof(student), "Student cannot be null.");
        }
        
        if (course is null)
        {
            throw new ArgumentNullException(nameof(course), "Course cannot be null.");
        }
         var result= student.GPA switch
         {
             >=3.5m=>"honors",
             >= 2.5m =>"GoodStanding",
             < 2.5m =>"AcademicWarning"
         };
        Console.WriteLine($"Student {student.Name} is in {result} status.");

          return new EnrollmentRecord (student.Id, course.Code,DateTime.UtcNow); 
    }
} */

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
// TODO2: Property that holds the delegate listener
   public Action<Student>? EnrollmentListener { get; set; }

    public void FinalizeEnrollment(Student s)
    {
        Console.WriteLine("Persisting to database...");

        EnrollmentListener?.Invoke(s);
    }
}