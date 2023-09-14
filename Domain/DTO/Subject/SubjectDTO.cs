using College.Domain.Common;

namespace College.Domain.DTO.Subject
{
    public class SubjectDTO
    {
        public int Code { get; set; }
        public Guid TeacherID { get; set; }
        public string Name { get; set; }
        public Enums.StateSubject StateSubject { get; set; }
    }
}