using AutoMapper;
using College.Business.IRepositories;
using College.Domain.Commands.Student;
using College.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace College.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _studentUseCases;
        private readonly IMapper _mapper;

        public StudentController(IStudent studentUseCases, IMapper mapper)
        {
            _studentUseCases = studentUseCases;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<Student> CreateStudentAsync([FromBody] CreateStudentCmd student) =>
            await _studentUseCases.CreateStudentAsync(_mapper.Map<Student>(student));

        [HttpPut]
        public async Task<Student> UpdateStudentAsync(string studentID, [FromBody] UpdateStudentCmd student) =>
            await _studentUseCases.UpdateStudentAsync(studentID, _mapper.Map<Student>(student));

        [HttpGet("{studentID}")]
        public async Task<Student> GetStudentByIdAsync(string studentID) =>
            await _studentUseCases.GetStudentByIdAsync(studentID);

        [HttpGet]
        public async Task<List<Student>> GetAllStudentsAsync() =>
            await _studentUseCases.GetAllStudentsAsync();

        [HttpDelete("{studentID}")]
        public async Task<int> DeleteStudentAsync(string studentID) =>
            await _studentUseCases.DeleteStudentAsync(studentID);
    }
}