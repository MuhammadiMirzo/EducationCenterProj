namespace Domain.Entities;

public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Teacher> Teachers { get; set; } 
}
