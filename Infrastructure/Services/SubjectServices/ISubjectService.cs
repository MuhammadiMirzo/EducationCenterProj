using Domain.Entities;

namespace Infrastructure.Services.SubjectServices;

public interface ISubjectService
{
    Task<List<Subject>> GetAllSubjects();
    Task<string> AddSubject(Subject model);
    Task<string> UpdateSubjectt(Subject model);
    Task<string> DeleteSubject(int subjectId);
}
