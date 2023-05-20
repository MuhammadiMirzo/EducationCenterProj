using Domain.DTOs.StudentDTOs;

namespace Domain.DTOs.GroupDTOs;

public class GetAllGroupDto
{
     public int Id { get; set; }
    public string Name { get; set; }=null!;
    public int CourseId { get; set; }
    public string CourseName { get; set; }=null!;
    public int TeacherId { get; set; }
    public string FullName { get; set; }=null!;
    public List<GetAllStudentDto> StudentDtos { get; set; }=null!;
}
