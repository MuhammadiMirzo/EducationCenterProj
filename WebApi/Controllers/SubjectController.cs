using Domain.Entities;
using Infrastructure.Services.SubjectService;
using Infrastructure.Services.SubjectServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route ("Api/Subjects")]
public class SubjectController:ControllerBase
{
    private ISubjectService _SubjectService;

    public SubjectController(ISubjectService SubjectService)
    {
        _SubjectService = SubjectService;
    }

    [HttpPost("Add Subject")]
    public async Task<string> AddSubject(Subject model)
    {
        return await _SubjectService.AddSubject(model);
    }

    [HttpGet("GEt All Subjects")]
    public async Task<List<Subject>> GetSubjects()
    {
        return await _SubjectService.GetAllSubjects();
    }

    [HttpPut("Update")]
    public async Task<string> UpdateSubject(Subject model)
    {
        return await _SubjectService.UpdateSubjectt(model);
    }

    [HttpDelete("Delete Subject")]
    public async Task<string> DeleteSubject(int SubjectId)
    {
        return await _SubjectService.DeleteSubject(SubjectId);
    }

}
