using Domain.Entities;

namespace Domain.DTOs.CourseDTOs;

public class AddCourseDto
{
    public string Name { get; set; } =null!;
    public DateTime StartDate { get; set; }
    public CourseStatus CourseStatus { get; set; }
  
}
