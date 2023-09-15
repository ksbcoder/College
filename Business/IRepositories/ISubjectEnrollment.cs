using College.Domain.DTO.SubjectEnrollments;
using College.Domain.Entities;

namespace College.Business.IRepositories
{
    public interface ISubjectEnrollment
    {
        public Task<SubjectEnrollmentDTO> AssignToStudentAsync(SubjectEnrollment subjectEnrollment);
        public Task<SubjectEnrollmentDTO> GetByIDsAsync(int code, string studentID);
        public Task<List<SubjectEnrollmentDTO>> GetEnrollmentsByIDsAsync(int? code, string studentID);
    }
}