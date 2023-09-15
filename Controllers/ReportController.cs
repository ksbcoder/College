using College.Business.IRepositories;
using College.Domain.DTO.Report;
using Microsoft.AspNetCore.Mvc;

namespace College.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReport _reportUseCases;

        public ReportController(IReport reportUseCases)
        {
            _reportUseCases = reportUseCases;
        }

        [HttpGet]
        public async Task<List<ReportDTO>> GetReport() =>
            await _reportUseCases.GetReport();
    }
}