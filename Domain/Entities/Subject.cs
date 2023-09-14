using College.Domain.Common;

namespace College.Domain.Entities
{
    public class Subject
    {
        public int Code { get; private set; }
        public string TeacherID { get; private set; }
        public string Name { get; private set; }
        public Enums.StateSubject StateSubject { get; private set; }

        public Subject() { }

        public void SetCode(int code)
        {
            Code = code;
        }
        public void SetTeacherID(string teacherID)
        {
            TeacherID = teacherID;
        }
        public void SetName(string name)
        {
            Name = name;
        }
        public void SetStateSubject(Enums.StateSubject stateSubject)
        {
            StateSubject = stateSubject;
        }
    }
}