namespace Domain.DTOs.GroupDTOs;

public class UpdateGroupDto
{
     public int Id { get; set; }
    public string Name { get; set; }=null!;
    public int CourseId { get; set; }
    public int TeacherId { get; set; }
}
