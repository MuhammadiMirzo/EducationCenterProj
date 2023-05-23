using Domain.DTOs.GroupDTOs;
using Infrastructure.Services.GroupServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("Api/Groups")]
public class GroupCotroller:ControllerBase
{
    private IGroupService _groupService;

    public GroupCotroller(IGroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpPost]
    public async Task<string> AddGroup(AddGroupDto model)
    {
        return await _groupService.AddGroupDto(model);
    }

    [HttpGet]
    public async Task<List<GetAllGroupDto>> GetGroups(GetAllGroupDto model)
    {
        return await _groupService.GetAllGroups();
    }
     [HttpPut]
    public async Task<string> UpdateGroups(UpdateGroupDto model)
    {
        return await _groupService.UpdateGroupDto(model);
    }

    [HttpDelete]
    public async Task<string> DeleteGroups(int groupId)
    {
        return await _groupService.DeleteGroupDto(groupId);
    }

}
