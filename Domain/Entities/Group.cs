namespace Domain.Entities;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; }=null!;
    public int CourseId { get; set; }
    public int TeacherId { get; set; }
    public virtual Course Course { get; set; }
    public virtual Teacher Teacher { get; set; }
    public virtual ICollection<Student> Students { get; set; }
}
