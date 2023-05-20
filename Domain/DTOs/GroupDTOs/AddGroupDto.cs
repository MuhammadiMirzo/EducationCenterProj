namespace Domain.DTOs.GroupDTOs;

public class AddGroupDto
{
    public string Name { get; set; }=null!;
    public int CourseId { get; set; }
    public int TeacherId { get; set; }
}
