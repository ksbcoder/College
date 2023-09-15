namespace College.Domain.DTO.Report
{
    public class ReportDTO
    {
        public int AcademicYear { get; set; }
        public string IdentificationStudent { get; set; }
        public string NameStudent { get; set; }
        public int Code { get; set; }
        public string NameSubject { get; set; }
        public string IdentificationTeacher { get; set; }
        public string NameTeacher { get; set; }
        public decimal FinalMark { get; set; }
    }
}