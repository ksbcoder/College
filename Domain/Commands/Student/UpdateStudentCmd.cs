using College.Domain.Common;

namespace College.Domain.Commands.Student
{
    public class UpdateStudentCmd
    {
        public string Identification { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public Enums.StateStudent StateStudent { get; set; }
    }
}