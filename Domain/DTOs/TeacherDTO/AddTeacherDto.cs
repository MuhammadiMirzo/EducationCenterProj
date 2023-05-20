namespace Domain.DTOs.TeacherDTO;

public class AddTeacherDto
{
      public int Id { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public int SubjectId { get; set; }
    
}
