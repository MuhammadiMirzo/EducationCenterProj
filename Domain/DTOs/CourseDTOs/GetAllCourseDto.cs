using Domain.DTOs.GroupDTOs;
using Domain.Entities;

namespace Domain.DTOs.CourseDTOs;

public class GetAllCourseDto
{
    public int Id { get; set; }
    public string Name { get; set; } =null!;
    public DateTime StartDate { get; set; }
    public CourseStatus CourseStatus { get; set; }
    public List<GetAllGroupDto> GetAllGroups { get; set; }=new List<GetAllGroupDto>();
}
