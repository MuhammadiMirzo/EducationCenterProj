namespace Domain.DTOs.StudentDTOs;

public class AddStudentDto
{
 
    public string FullName { get; set; }=null!;
    public string PhoneNumber { get; set; }=null!;
    public string Email { get; set; }=null!;
    public int GroupId { get; set; }
    
}
