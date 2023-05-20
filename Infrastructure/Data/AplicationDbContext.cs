using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AplicationDbContext:DbContext
{
    public AplicationDbContext(DbContextOptions<AplicationDbContext> op):base(op)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder builder){
     
     builder.Entity<Subject>()
                .HasData(new List<Subject>{
                    new Subject{ 
                        Id = 1,
                        Name = "C++"
                    },
                    new Subject{ 
                        Id = 2,
                        Name = "C#"
                    },
                    new Subject{ 
                        Id = 3,
                        Name = "Java"
                    },
                    new Subject{ 
                        Id = 4,
                        Name = "Python"
                    }

                });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
            optionsBuilder.UseLazyLoadingProxies();
    }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Student> Students{ get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
}
