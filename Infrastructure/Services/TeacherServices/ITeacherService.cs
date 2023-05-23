using Domain.DTOs.TeacherDTO;

namespace Infrastructure.Services.TeacherService;

public interface ITeacherService
{
    Task<string> AddTeacher(AddTeacherDto model);
    Task<List<GetAllTeacherDto>> GetAllTeachers();
    Task<string> UpdateTeacher(UpdateTeacherDto model);
    Task<string> DeleteTeacher(int id);
}
