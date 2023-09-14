using College.Domain.Common;

namespace College.Domain.Commands.Teacher
{
    public class UpdateTeacherCmd
    {
        public string Identification { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public Enums.StateTeacher StateTeacher { get; set; }
    }
}