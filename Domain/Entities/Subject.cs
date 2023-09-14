using College.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace College.Domain.Entities
{
    public class Subject
    {
        [Key]
        public int Code { get; private set; }

        [ForeignKey("Teacher")]
        public Guid TeacherID { get; private set; }
        public string Name { get; private set; }
        public Enums.StateSubject StateSubject { get; private set; }

        // Navegación a Teacher
        public Teacher Teacher { get; set; }

        public Subject() { }

        #region Setters
        public void SetCode(int code)
        {
            Code = code;
        }
        public void SetTeacherID(Guid teacherID)
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
        #endregion

        #region Factory
        public static Subject SetDetailsToSubject(Subject subject)
        {
            subject.SetStateSubject(Enums.StateSubject.Active);
            return subject;
        }
        #endregion
    }
}