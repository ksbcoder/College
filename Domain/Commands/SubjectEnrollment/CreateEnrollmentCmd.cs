namespace College.Domain.Commands.SubjectEnrollments
{
    public class CreateEnrollmentCmd
    {
        public int SubjectCode { get; set; }
        public Guid StudentID { get; set; }
        public int AcademicYear { get; set; }
    }
}