using College.Domain.Common;

namespace College.Domain.Entities
{
    public class Teacher
    {
        public Guid TeacherID { get; private set; }
        public string Identification { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }
        public Enums.StateTeacher StateTeacher { get; private set; }

        public Teacher() { }

        #region Setters
        public void SetTeacherID(Guid teacherID)
        {
            TeacherID = teacherID;
        }
        public void SetIdentification(string identification)
        {
            Identification = identification;
        }
        public void SetName(string name)
        {
            Name = name;
        }
        public void SetLastName(string lastName)
        {
            LastName = lastName;
        }
        public void SetAge(int age)
        {
            Age = age;
        }
        public void SetAddress(string address)
        {
            Address = address;
        }
        public void SetPhone(string phone)
        {
            Phone = phone;
        }
        public void SetStateTeacher(Enums.StateTeacher stateTeacher)
        {
            StateTeacher = stateTeacher;
        }
        #endregion

        #region Factory
        public static Teacher SetDetailsTeacher(Teacher teacher)
        {
            teacher.SetStateTeacher(Enums.StateTeacher.Active);
            return teacher;
        }
        #endregion
    }
}