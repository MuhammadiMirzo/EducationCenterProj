using Domain.DTOs.StudentDTOs;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.StudentServices;

public class StudentService:IStudentService
{
    private AplicationDbContext _dbContext;

    public StudentService(AplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> AddStudentDto(AddStudentDto model)
    {
        var student = new Student
        {
            Email = model.Email,
            GroupId = model.GroupId,
            FullName = model.FullName,
            PhoneNumber = model.PhoneNumber
        };
         await _dbContext.Students.AddAsync(student);
         var st = await _dbContext.SaveChangesAsync();
         if(st==0)return "Student was not added";
         return "Student seccessfully Added";
    }

    public async Task<string> DeleteStudent(int studentId)
    {
        var student = await _dbContext.Students.FindAsync(studentId);
        if(student==null)return "Student was not found!";

        _dbContext.Remove(student);
        var del = await _dbContext.SaveChangesAsync();
        if(del==0)return "Student was not deleted";
        return "Successfully deleted";
    }

    public async Task<List<GetAllStudentDto>> GetAllStudents()
    {
        var students = await _dbContext.Students.ToListAsync();

        var allStudents = students.Select(students=>new GetAllStudentDto
        {
            Email = students.Email,
            FullName = students.FullName,
            GroupName = students.Group.Name,
            PhoneNumber = students.PhoneNumber
        }).ToList();

        return allStudents;

    }

    public async Task<string> UpdateStudent(UpdateStudentDto model)
    {
        var student = await _dbContext.Students.FindAsync(model.Id);
        if(student==null)return "Student was not found";
        student.Email = model.Email;
        student.FullName = model.FullName;
        student.GroupId = model.GroupId;
        student.PhoneNumber = model.PhoneNumber; 

        var sev = await _dbContext.SaveChangesAsync();
        if(sev==0)return "Student was Not updated!";
        return "Student Updated ";
    }
}
