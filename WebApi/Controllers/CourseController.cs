using Domain.DTOs.CourseDTOs;
using Infrastructure.Services.CourseServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("Api/Course")]
public class CourseController:ControllerBase
{
    private ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet("Get all Courses")]
    public async Task<List<GetAllCourseDto>> GetAllCourseDtos()
    {
        return await _courseService.GetAllCourses();
    }

    [HttpPost("Add Course")]
    public async Task<string> AddCourseDto(AddCourseDto model)
    {
        return await _courseService.AddCourse(model);
    }

    [HttpPut("Update Course")]
    public async Task<string> UpdateCourseDto(UpdateCourseDto model)
    {
        return await _courseService.UpdateCourse(model);
    }

    [HttpDelete("Delete Course")]
    public async Task<string> DeleteCourse(int courseId)
    {
        return await _courseService.DeleteCource(courseId);
    }

}
