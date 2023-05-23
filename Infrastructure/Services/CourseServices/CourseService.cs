using Domain.DTOs.CourseDTOs;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Domain.DTOs.GroupDTOs;
using Domain.DTOs.StudentDTOs;

namespace Infrastructure.Services.CourseServices;
public class CourseService:ICourseService
{
    private readonly AplicationDbContext _dbContext;
    public CourseService(AplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> AddCourse(AddCourseDto model)
    {
        var course = new Course()
        {
            Name = model.Name,
            CourseStatus = model.CourseStatus,
            StartDate = model.StartDate      
        };
        await _dbContext.Courses.AddAsync(course);
        var result = await _dbContext.SaveChangesAsync();

        if(result==0) return "Data not added !";
        return "Data successfully added !";
    }

    public async Task<string> DeleteCource(int courseId)
    {
        var course = await _dbContext.Courses.FindAsync(courseId);
        if(course==null)return "Not found";
        _dbContext.Courses.Remove(course);
      var result = await _dbContext.SaveChangesAsync();

        if(result==0) return "Data not deleted !";
        return "Data successfully deleted";
    }

    public async Task<List<GetAllCourseDto>> GetAllCourses()
    {
        var courses = await _dbContext.Courses.ToListAsync();
        var allcour = courses.Select(course=>new GetAllCourseDto
        {
            CourseStatus = course.CourseStatus,
            Name = course.Name,
            GetAllGroups = course.Groups
                            .Where(x=>x.CourseId==course.Id)
                            .Select(group=>new GetAllGroupDto
                            {
                                Id=group.Id,
                                Name=group.Name,
                                TeacherId=group.TeacherId,
                                FullName=group.Teacher.FullName,
                                StudentDtos=group.Students
                              .Where(y=>y.GroupId==group.Id)
                              .Select(student=>new GetAllStudentDto
                              {
                                    Id = student.Id,
                                    FullName = student.FullName
                              }).ToList()
                            }).ToList(),

        }).ToList();
        return allcour;
    }

    public async Task<string> UpdateCourse(UpdateCourseDto model)
    {
        var course = await _dbContext.Courses.FindAsync(model.Id);
        
        if(course==null) return "Data not found !";

        course.CourseStatus = model.CourseStatus;
        course.Name = model.Name;
        course.StartDate = model.StartDate;

        var result = await _dbContext.SaveChangesAsync();

        if(result==0) return "Data not updated !";
        return "Data successfully updated";
    }
}
