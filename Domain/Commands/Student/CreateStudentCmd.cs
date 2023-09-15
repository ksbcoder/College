namespace College.Domain.Commands.Student
{
    public class CreateStudentCmd
    {
        public string Identification { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}