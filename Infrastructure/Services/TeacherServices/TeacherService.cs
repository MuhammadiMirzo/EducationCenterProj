using Domain.DTOs.TeacherDTO;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.TeacherService;

public class TeacherService : ITeacherService
{
    private AplicationDbContext _dbContext;

    public TeacherService(AplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<string> AddTeacher(AddTeacherDto model)
    {
        var teacher = new Teacher
        {
            Email = model.Email,
            FullName = model.FullName,
            PhoneNumber = model.PhoneNumber,
            SubjectId = model.SubjectId

        };
        await _dbContext.Teachers.AddAsync(teacher);
        await _dbContext.SaveChangesAsync();
        return "teacher was added";
    }

    public async Task<string> DeleteTeacher(int id)
    {
        var teach = await _dbContext.Teachers.FindAsync(id);
        if(teach==null) return "teacher was not found";
        _dbContext.Teachers.Remove(teach);
        await _dbContext.SaveChangesAsync();
        return "teacher was deleted";
    }

    public async Task<List<GetAllTeacherDto>> GetAllTeachers()
    {
        var teachers = await _dbContext.Teachers.ToListAsync();
        var allTeachs = teachers.Select(teachers=>new GetAllTeacherDto{
            Email = teachers.Email,
            FullName = teachers.FullName,
            Id = teachers.Id,
            PhoneNumber = teachers.PhoneNumber,
            SubjectName = teachers.Subject.Name
        }).ToList();

        return allTeachs;
    }

    public async Task<string> UpdateTeacher(UpdateTeacherDto model)
    {
         var find = await _dbContext.Teachers.FindAsync(model.Id);
         if(find==null)return "teacher was not found";
         find.Email = model.Email;
         find.FullName = model.FullName;
         find.PhoneNumber = model.PhoneNumber;
         find.SubjectId = model.SubjectId;

         await _dbContext.SaveChangesAsync();

         return "teacher Updated";
    }
}
