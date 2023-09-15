using College.Domain.DTO.Report;

namespace College.Business.IRepositories
{
    public interface IReport
    {
        Task<List<ReportDTO>> GetReport();
    }
}