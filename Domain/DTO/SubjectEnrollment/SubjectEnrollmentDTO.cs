using College.Domain.Common;

namespace College.Domain.DTO.SubjectEnrollments
{
    public class SubjectEnrollmentDTO
    {
        public Guid EnrollmentID { get; set; }
        public int SubjectCode { get; set; }
        public Guid StudentID { get; set; }
        public decimal FinalMark { get; set; }
        public DateTime EnrollmentRegister { get; set; }
        public int AcademicYear { get; set; }
        public Enums.StateSubjectEnrollment StateSubjectEnrollment { get; set; }
    }
}