using Domain.DTOs.CourseDTOs;

namespace Infrastructure.Services.CourseServices;

public interface ICourseService
{
    Task<List<GetAllCourseDto>> GetAllCourses();
    Task<string> AddCourse(AddCourseDto model);
    Task<string> UpdateCourse(UpdateCourseDto model);
    Task<string> DeleteCource(int courseId);

}
