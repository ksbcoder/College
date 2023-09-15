using AutoMapper;
using College.Business.IRepositories;
using College.Domain.Commands.SubjectEnrollments;
using College.Domain.DTO.SubjectEnrollments;
using College.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace College.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectEnrollmentController : ControllerBase
    {
        private readonly ISubjectEnrollment _subjectEnrollmentsUseCases;
        private readonly IMapper _mapper;

        public SubjectEnrollmentController(ISubjectEnrollment subjectEnrollmentsUseCases, IMapper mapper)
        {
            _subjectEnrollmentsUseCases = subjectEnrollmentsUseCases;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<SubjectEnrollmentDTO> AssignToStudent([FromBody] CreateEnrollmentCmd enrollmentCmd) =>
            await _subjectEnrollmentsUseCases.AssignToStudentAsync(_mapper.Map<SubjectEnrollment>(enrollmentCmd));
    }
}