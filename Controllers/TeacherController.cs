using AutoMapper;
using College.Business.IRepositories;
using College.Domain.Commands.Teacher;
using College.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace College.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacher _teacherUseCases;
        private readonly IMapper _mapper;
        public TeacherController(ITeacher teacherUseCases, IMapper mapper)
        {
            _teacherUseCases = teacherUseCases;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<Teacher> CreateTeacherAsync([FromBody] CreateTeacherCmd teacher) =>
            await _teacherUseCases.CreateTeacherAsync(_mapper.Map<Teacher>(teacher));

        [HttpPut]
        public async Task<Teacher> UpdateTeacherAsync(string teacherID, [FromBody] UpdateTeacherCmd teacher) =>
            await _teacherUseCases.UpdateTeacherAsync(teacherID, _mapper.Map<Teacher>(teacher));

        [HttpGet("{ID}")]
        public async Task<Teacher> GetTeacherByIdAsync(string ID) =>
            await _teacherUseCases.GetTeacherByIdAsync(ID);

        [HttpGet]
        public async Task<List<Teacher>> GetAllTeachersAsync() =>
            await _teacherUseCases.GetAllTeachersAsync();
    }
}