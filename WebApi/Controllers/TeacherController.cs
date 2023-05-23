
using Domain.DTOs.TeacherDTO;
using Infrastructure.Services.TeacherService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route ("Api/Teachers")]
public class TeacherController:ControllerBase
{
    private ITeacherService _TeacherService;

    public TeacherController(ITeacherService TeacherService)
    {
        _TeacherService = TeacherService;
    }

    [HttpPost("Add Teacher")]
    public async Task<string> AddTeacher(AddTeacherDto model)
    {
        return await _TeacherService.AddTeacher(model);
    }

    [HttpGet("GEt All Teachers")]
    public async Task<List<GetAllTeacherDto>> GetTeachers()
    {
        return await _TeacherService.GetAllTeachers();
    }

    [HttpPut("Update")]
    public async Task<string> UpdateTeacher(UpdateTeacherDto model)
    {
        return await _TeacherService.UpdateTeacher(model);
    }

    [HttpDelete("Delete Teacher")]
    public async Task<string> DeleteTeacher(int TeacherId)
    {
        return await _TeacherService.DeleteTeacher(TeacherId);
    }

}
