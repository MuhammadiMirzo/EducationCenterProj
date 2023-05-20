namespace Domain.Entities;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } =null!;
    public DateTime StartDate { get; set; }
    public CourseStatus CourseStatus { get; set; }
    public virtual ICollection<Group> Groups{get;set;}



}
public enum CourseStatus
{
    Active =  1,
    InActive = 2
}
