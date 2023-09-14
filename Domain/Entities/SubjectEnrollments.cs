using College.Domain.Common;

namespace College.Domain.Entities
{
    public class SubjectEnrollments
    {
        public int SubjectCode { get; private set; }
        public string StudentID { get; private set; }
        public decimal FinalMark { get; private set; }
        public DateTime EnrollmentRegister { get; private set; }
        public int AcademicYear { get; private set; }
        public Enums.StateSubjectEnrollment StateSubjectEnrollment { get; private set; }

        public SubjectEnrollments() { }

        public void SetSubjectCode(int subjectCode)
        {
            SubjectCode = subjectCode;
        }
        public void SetStudentID(string studentID)
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
            StateSubjectEnrollment = stateSubjectEnrollment;
        }
    }
}