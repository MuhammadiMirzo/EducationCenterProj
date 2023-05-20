namespace Domain.DTOs.TeacherDTO;

public class GetAllTeacherDto
{
      public int Id { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public int SubjectId { get; set; }
    public string SubjectName  { get; set; }
}
