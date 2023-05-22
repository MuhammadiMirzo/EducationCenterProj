using Domain.DTOs.GroupDTOs;
using Domain.DTOs.StudentDTOs;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.GroupServices;

public class GroupService : IGroupService
{
     private readonly AplicationDbContext _dbContext;

     public GroupService(AplicationDbContext dbContext)
     {
        _dbContext = dbContext;
     }

    
    public async Task<string> AddGroupDto(AddGroupDto model)
    {
        var course = await _dbContext.Courses.FirstOrDefaultAsync(x=>x.Id==model.CourseId);
        if(course==null) return "course not found !";

        var teacher = await _dbContext.Teachers.FirstOrDefaultAsync(x=>x.Id==model.TeacherId);
        if(teacher==null) return "teacher not found !";

        var group = new Group
        {
            CourseId = model.CourseId,
            Name = model.Name,
            TeacherId = model.TeacherId,
        };

        if(group==null)return "Something went wrong";

         await _dbContext.AddAsync(model);
        var add = await _dbContext.SaveChangesAsync();

        if(add==0)return "Not added";
        return "New group Successifully added";
    }

    public async Task<string> DeleteGroupDto(int groupId)
    {
        var findGroup = _dbContext.Groups.FindAsync(groupId);
        if(findGroup==null)return "Group was not found";
        _dbContext.Remove(findGroup);
        var delete = await _dbContext.SaveChangesAsync();

        if(delete==0)return "was not deleted";
        return "Group deleted!";
    }

    public async Task<List<GetAllGroupDto>> GetAllGroups()
    {
        var groups = await _dbContext.Groups.ToListAsync();
        var allgroups = groups.Select(groups=>new GetAllGroupDto
        {
            CourseName = groups.Course.Name,
            Name = groups.Name,
            StudentDtos = groups.Students.Where(x=>x.GroupId==groups.Id)
            .Select(student=>new GetAllStudentDto
            {
                Id = student.Id,
                FullName = student.FullName

            }).ToList()

        }).ToList();     
        
        return allgroups;  
    }

    public async Task<string> UpdateGroupDto(UpdateGroupDto model)
    {
        var group =await  _dbContext.Groups.FindAsync(model.Id);

        if(group==null) return "Not found";

        group.Name = model.Name;
        group.TeacherId  = model.TeacherId;
        group.CourseId = model.CourseId;

        var save = await _dbContext.SaveChangesAsync();
        if(save==0)return "Was not saved";
        return "Group was updated";
    }
}
