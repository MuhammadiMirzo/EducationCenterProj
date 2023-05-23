using Domain.DTOs.TeacherDTO;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Services.SubjectServices;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.SubjectService;

public class SubjectService : ISubjectService
{
    private AplicationDbContext _dbContext;

    public SubjectService(AplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<string> AddSubject(Subject model)
    {
        await _dbContext.Subjects.AddAsync(model);
        var add = await _dbContext.SaveChangesAsync();
        if(add==0)return "Subject NOt added";
        return "Subject added";

    }

    public async Task<string> DeleteSubject(int subjectId)
    {
        var found = await _dbContext.Subjects.FindAsync(subjectId);
        if(found==null) return "subject NOt found";
         _dbContext.Subjects.Remove(found);
         await _dbContext.SaveChangesAsync();
         return "subject deleted";
    }

    public async Task<List<Subject>> GetAllSubjects()
    {
        var subject =  await _dbContext.Subjects.ToListAsync();
        var allsubjects = subject.Select(subject => new Subject{
            Name = subject.Name,
            
        }).ToList();

        return allsubjects;
    }

    public async Task<string> UpdateSubjectt(Subject model)
    {
        var find = await _dbContext.Subjects.FindAsync(model.Id);
        if(find==null)return "subjext not found";
        find.Name = model.Name;
        find.Teachers = model.Teachers;
        await _dbContext.SaveChangesAsync();

        return "subject updated";
    }
}
