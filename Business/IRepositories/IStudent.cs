using College.Domain.Entities;

namespace College.Business.IRepositories
{
    public interface IStudent
    {
        Task<Student> CreateStudentAsync(Student student);
        Task<Student> UpdateStudentAsync(string studentID, Student student);
        Task<Student> GetStudentByIdAsync(string studentID);
        Task<List<Student>> GetAllStudentsAsync();
        Task<int> DeleteStudentAsync(string studentID);
    }
}