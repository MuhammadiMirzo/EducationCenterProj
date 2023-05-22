using Domain.DTOs.GroupDTOs;
namespace Infrastructure.Services.GroupServices;

public interface IGroupService
{
    Task<List<GetAllGroupDto>> GetAllGroups();
    Task<string> AddGroupDto(AddGroupDto model);
    Task<string> DeleteGroupDto(int groupId);
    Task<string> UpdateGroupDto(UpdateGroupDto model);
} 