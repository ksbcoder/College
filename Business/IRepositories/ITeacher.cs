using College.Domain.Entities;

namespace College.Business.IRepositories
{
    public interface ITeacher
    {
        Task<Teacher> CreateTeacherAsync(Teacher teacher);
        Task<Teacher> UpdateTeacherAsync(string teacherID, Teacher teacher);
        Task<Teacher> GetTeacherByIdAsync(string teacherID);
        Task<List<Teacher>> GetAllTeachersAsync();
    }
}