using Infrastructure.Data;
using Infrastructure.Services.CourseServices;
using Infrastructure.Services.GroupServices;
using Infrastructure.Services.StudentServices;
using Infrastructure.Services.SubjectService;
using Infrastructure.Services.SubjectServices;
using Infrastructure.Services.TeacherService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AplicationDbContext>(config=>config.UseSqlite(
    builder.Configuration.GetConnectionString("DefaultConnection")
));
builder.Services.AddControllers();
builder.Services.AddScoped<ICourseService,CourseService>();
builder.Services.AddScoped<IGroupService,GroupService>();
builder.Services.AddScoped<IStudentService,StudentService>();
builder.Services.AddScoped<ITeacherService,TeacherService>();
builder.Services.AddScoped<ISubjectService,SubjectService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
