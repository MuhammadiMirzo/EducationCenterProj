using Domain.DTOs.StudentDTOs;

namespace Infrastructure.Services.StudentServices;

public interface IStudentService
{
    Task<List<GetAllStudentDto>> GetAllStudents();
    Task<string> AddStudentDto(AddStudentDto model);
    Task<string> UpdateStudent(UpdateStudentDto model);
    Task<string> DeleteStudent(int studentId);
}
