using College.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace College.Domain.Entities
{
    public class SubjectEnrollment
    {
        [Key]
        public Guid EnrollmentID { get; private set; }
        [ForeignKey("Subject")]
        public int SubjectCode { get; private set; }
        [ForeignKey("Student")]
        public Guid StudentID { get; private set; }
        public decimal FinalMark { get; private set; }
        public DateTime EnrollmentRegister { get; private set; }
        public int AcademicYear { get; private set; }
        public Enums.StateSubjectEnrollment StateEnrollment { get; private set; }

        // Navegación a Subject y Student
        public Subject Subject { get; set; }
        public Student Student { get; set; }

        public SubjectEnrollment() { }

        #region Setters
        public void SetEnrollmentID(Guid enrollmentID)
        {
            EnrollmentID = enrollmentID;
        }
        public void SetSubjectCode(int subjectCode)
        {
            SubjectCode = subjectCode;
        }
        public void SetStudentID(Guid studentID)
        {
            StudentID = studentID;
        }
        public void SetFinalMark(decimal finalMark)
        {
            FinalMark = finalMark;
        }
        public void SetEnrollmentRegister(DateTime enrollmentRegister)
        {
            EnrollmentRegister = enrollmentRegister;
        }
        public void SetAcademicYear(int academicYear)
        {
            AcademicYear = academicYear;
        }
        public void SetStateSubjectEnrollment(Enums.StateSubjectEnrollment stateSubjectEnrollment)
        {
            StateEnrollment = stateSubjectEnrollment;
        }
        #endregion

        #region Factory
        public static SubjectEnrollment SetDetailsToEnrollment(SubjectEnrollment subjectEnrollment)
        {
            subjectEnrollment.SetFinalMark(0);
            subjectEnrollment.SetEnrollmentRegister(DateTime.Now);
            subjectEnrollment.SetStateSubjectEnrollment(Enums.StateSubjectEnrollment.Active);

            return subjectEnrollment;
        }
        #endregion
    }
}