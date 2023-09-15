namespace College.Domain.Commands.Teacher
{
    public class CreateTeacherCmd
    {
        public string Identification { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}