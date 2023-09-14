using College.Domain.DTO.Subject;
using College.Domain.Entities;

namespace College.Business.IRepositories
{
    public interface ISubject
    {
        Task<SubjectDTO> CreateSubjectAsync(Subject subject);
        Task<SubjectDTO> AssignToTeacherAsync(int code, string teacherID);
        Task<SubjectDTO> GetSubjectByIdAsync(int code);
        Task<List<SubjectDTO>> GetAllSubjectsAsync();
    }
}