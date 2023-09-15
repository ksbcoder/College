using College.Business.IRepositories;
using College.Business.Report;
using College.Domain.DTO.Report;
using System.Data;
using System.Data.SqlClient;

namespace College.Infrastructure.SQLServerAdapter.ReposImplementation
{
    public class ReportImpl : IReport
    {
        public ReportImpl() { }

        public async Task<List<ReportDTO>> GetReport()
        {
            List<ReportDTO> report = new();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Ruta al directorio raíz de tu aplicación
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            string connectionString = configuration.GetConnectionString("urlConnectionSQL");

            string query = @"
            SELECT DISTINCT
                    SE.AcademicYear AS AcademicYear,
                    S.Identification AS IdentificationStudent,
                    S.Name AS NameStudent,
                    SU.Code AS Code,
                    SU.Name AS NameSubject,
                    T.Identification AS IdentificationTeacher,
                    T.Name AS NameTeacher,
                    SE.FinalMark AS FinalMark
                FROM SubjectEnrollments SE
                INNER JOIN Students S ON SE.StudentID = S.StudentID
                INNER JOIN Subjects SU ON SE.SubjectCode = SU.Code
                INNER JOIN Teachers T ON SU.TeacherID = T.TeacherID;";

            using SqlConnection connection = new(connectionString);
            connection.Open();

            using SqlCommand command = new(query, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var register = new ReportDTO()
                {
                    AcademicYear = reader.GetInt32("AcademicYear"),
                    IdentificationStudent = reader.GetString("IdentificationStudent"),
                    NameStudent = reader.GetString("NameStudent"),
                    Code = reader.GetInt32("Code"),
                    NameSubject = reader.GetString("NameSubject"),
                    IdentificationTeacher = reader.GetString("IdentificationTeacher"),
                    NameTeacher = reader.GetString("NameTeacher"),
                    FinalMark = reader.GetDecimal("FinalMark")
                };
                report.Add(register);
            }

            connection.Close();

            ReportGenerator.GenerateExcelReport(report);
            return report;
        }
    }
}