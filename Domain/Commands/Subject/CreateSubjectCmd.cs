namespace College.Domain.Commands.Subject
{
    public class CreateSubjectCmd
    {
        public Guid TeacherID { get; set; }
        public string Name { get; set; }
    }
}