using Ardalis.GuardClauses;
using College.Business.IRepositories;
using College.Domain.Entities;
using College.Wrappers;
using Microsoft.EntityFrameworkCore;

namespace College.Infrastructure.SQLServerAdapter.ReposImplementation
{
    public class TeacherImpl : ITeacher
    {
        private readonly Gateway.AppDbContext _dbContext;

        public TeacherImpl(Gateway.AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Teacher> CreateTeacherAsync(Teacher teacher)
        {
            Teacher.SetDetailsTeacher(teacher);

            Guard.Against.NullOrEmpty(teacher.Identification, nameof(teacher.Identification));
            Guard.Against.NullOrEmpty(teacher.Name, nameof(teacher.Name));
            Guard.Against.NullOrEmpty(teacher.LastName, nameof(teacher.LastName));
            Guard.Against.NegativeOrZero(teacher.Age, nameof(teacher.Age));
            Guard.Against.Null(teacher.Age, nameof(teacher.Age));
            Guard.Against.NullOrEmpty(teacher.Address, nameof(teacher.Address));
            Guard.Against.NullOrEmpty(teacher.Phone, nameof(teacher.Phone));
            Guard.Against.EnumOutOfRange(teacher.StateTeacher, nameof(teacher.StateTeacher));

            _dbContext.Teachers.Add(teacher);

            var teacherCreated = await _dbContext.SaveChangesAsync();

            return teacherCreated == 0 ?
                throw new ApiException("The teacher was not created.", StatusCodes.Status500InternalServerError) :
                teacher;
        }

        public async Task<List<Teacher>> GetAllTeachersAsync()
        {
            var teachers = await _dbContext.Teachers.ToListAsync();
            return teachers.Count == 0 ?
                throw new ApiException("There are not teachers.", StatusCodes.Status404NotFound) :
                teachers;
        }

        public async Task<Teacher> GetTeacherByIdAsync(string identification)
        {
            var teacher = await _dbContext.Teachers.FirstOrDefaultAsync(x => x.TeacherID == Guid.Parse(identification));
            return teacher ?? throw new ApiException("The teacher was not found.", StatusCodes.Status404NotFound);
        }

        public async Task<Teacher> UpdateTeacherAsync(string teacherID, Teacher teacher)
        {
            var teacherFound = await _dbContext.Teachers.FirstOrDefaultAsync(x => x.TeacherID == Guid.Parse(teacherID)) ??
                throw new ApiException("The teacher was not found.", StatusCodes.Status404NotFound);

            Guard.Against.NullOrEmpty(teacher.Identification, nameof(teacher.Identification));
            Guard.Against.NullOrEmpty(teacher.Name, nameof(teacher.Name));
            Guard.Against.NullOrEmpty(teacher.LastName, nameof(teacher.LastName));
            Guard.Against.NegativeOrZero(teacher.Age, nameof(teacher.Age));
            Guard.Against.Null(teacher.Age, nameof(teacher.Age));
            Guard.Against.NullOrEmpty(teacher.Address, nameof(teacher.Address));
            Guard.Against.NullOrEmpty(teacher.Phone, nameof(teacher.Phone));
            Guard.Against.EnumOutOfRange(teacher.StateTeacher, nameof(teacher.StateTeacher));

            teacherFound.SetIdentification(teacher.Identification);
            teacherFound.SetName(teacher.Name);
            teacherFound.SetLastName(teacher.LastName);
            teacherFound.SetAge(teacher.Age);
            teacherFound.SetAddress(teacher.Address);
            teacherFound.SetPhone(teacher.Phone);
            teacherFound.SetStateTeacher(teacher.StateTeacher);

            var teacherUpdated = await _dbContext.SaveChangesAsync();

            teacher.SetTeacherID(teacherFound.TeacherID);
            return teacherUpdated == 0 ?
                throw new ApiException("The teacher was not updated.", StatusCodes.Status500InternalServerError) :
                teacher;
        }
    }
}