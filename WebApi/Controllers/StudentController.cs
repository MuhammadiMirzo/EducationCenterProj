using Domain.DTOs.StudentDTOs;
using Infrastructure.Services.StudentServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route ("Api/Students")]
public class StudentController:ControllerBase
{
    private IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpPost("Add Student")]
    public async Task<string> AddStudent(AddStudentDto model)
    {
        return await _studentService.AddStudentDto(model);
    }

    [HttpGet("GEt All Students")]
    public async Task<List<GetAllStudentDto>> GetStudents()
    {
        return await _studentService.GetAllStudents();
    }

    [HttpPut("Update")]
    public async Task<string> UpdateStudent(UpdateStudentDto model)
    {
        return await _studentService.UpdateStudent(model);
    }

    [HttpDelete("Delete Student")]
    public async Task<string> DeleteStudent(int studentId)
    {
        return await _studentService.DeleteStudent(studentId);
    }


}
