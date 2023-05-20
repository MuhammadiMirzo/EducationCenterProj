using Domain.Entities;

namespace Domain.DTOs.CourseDTOs;

public class UpdateCourseDto
{
    public int Id { get; set; }
    public string Name { get; set; } =null!;
    public DateTime StartDate { get; set; }
    public CourseStatus CourseStatus { get; set; }
}
