using AutoMapper;
using College.Business.IRepositories;
using College.Domain.Commands.Subject;
using College.Domain.DTO.Subject;
using College.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace College.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubject _subjectUseCases;
        private readonly IMapper _mapper;

        public SubjectController(ISubject subjectUseCases, IMapper mapper)
        {
            _subjectUseCases = subjectUseCases;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<SubjectDTO> CreateSubject([FromBody] CreateSubjectCmd subject)
            => await _subjectUseCases.CreateSubjectAsync(_mapper.Map<Subject>(subject));

        [HttpPatch("{code}/{teacherID}")]
        public async Task<SubjectDTO> AssignToTeacher(int code, string teacherID)
            => await _subjectUseCases.AssignToTeacherAsync(code, teacherID);

        [HttpGet("{code}")]
        public async Task<SubjectDTO> GetSubjectById(int code)
            => await _subjectUseCases.GetSubjectByIdAsync(code);

        [HttpGet]
        public async Task<List<SubjectDTO>> GetAllSubjects()
            => await _subjectUseCases.GetAllSubjectsAsync();
    }
}