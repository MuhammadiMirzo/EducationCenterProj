namespace Domain.Entities;

public class Teacher
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public int SubjectId { get; set; }
    public virtual Subject Subject { get; set; }
}
