using Ardalis.GuardClauses;
using College.Business.IRepositories;
using College.Domain.Entities;
using College.Infrastructure.SQLServerAdapter.Gateway;
using College.Wrappers;
using Microsoft.EntityFrameworkCore;
using static College.Domain.Common.Enums;

namespace College.Infrastructure.SQLServerAdapter.ReposImplementation
{
    public class StudentImpl : IStudent
    {
        private readonly AppDbContext _dbContext;

        public StudentImpl(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Student> CreateStudentAsync(Student student)
        {
            Student.SetDetailsStudent(student);

            Guard.Against.NullOrEmpty(student.Identification, nameof(student.Identification));
            Guard.Against.NullOrEmpty(student.Name, nameof(student.Name));
            Guard.Against.NullOrEmpty(student.LastName, nameof(student.LastName));
            Guard.Against.NegativeOrZero(student.Age, nameof(student.Age));
            Guard.Against.Null(student.Age, nameof(student.Age));
            Guard.Against.NullOrEmpty(student.Address, nameof(student.Address));
            Guard.Against.NullOrEmpty(student.Phone, nameof(student.Phone));
            Guard.Against.EnumOutOfRange(student.StateStudent, nameof(student.StateStudent));

            _dbContext.Students.Add(student);

            var studentCreated = await _dbContext.SaveChangesAsync();

            return studentCreated == 0 ?
                throw new ApiException("The student was not created.", StatusCodes.Status500InternalServerError) :
                student;
        }

        public async Task<int> DeleteStudentAsync(string studentID)
        {
            var studentFound = await _dbContext.Students.FirstOrDefaultAsync(s => s.StudentID == Guid.Parse(studentID)
                                    && s.StateStudent == StateStudent.Active)
                ?? throw new ApiException("The student was not found, maybe was eliminated already.", StatusCodes.Status404NotFound);

            studentFound.SetStateStudent(StateStudent.Inactive);

            var studentDeleted = await _dbContext.SaveChangesAsync();

            return studentDeleted == 0 ?
                throw new ApiException("The student was not deleted.", StatusCodes.Status500InternalServerError) :
                StatusCodes.Status200OK;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            var students = await _dbContext.Students.Where(s => s.StateStudent == StateStudent.Active).ToListAsync();
            return students.Count == 0 ?
                throw new ApiException("There are not students.", StatusCodes.Status404NotFound) :
                students;
        }

        public async Task<Student> GetStudentByIdAsync(string studentID)
        {
            var student = await _dbContext.Students.FirstOrDefaultAsync(s => s.StudentID == Guid.Parse(studentID)
                                && s.StateStudent == StateStudent.Active);
            return student ?? throw new ApiException("The student was not found.", StatusCodes.Status404NotFound);
        }

        public async Task<Student> UpdateStudentAsync(string studentID, Student student)
        {
            var studentFound = await _dbContext.Students.FirstOrDefaultAsync(s => s.StudentID == Guid.Parse(studentID)
                                    && s.StateStudent == StateStudent.Active)
                ?? throw new ApiException("The student was not found or was eliminated.", StatusCodes.Status404NotFound);

            Guard.Against.NullOrEmpty(student.Identification, nameof(student.Identification));
            Guard.Against.NullOrEmpty(student.Name, nameof(student.Name));
            Guard.Against.NullOrEmpty(student.LastName, nameof(student.LastName));
            Guard.Against.NegativeOrZero(student.Age, nameof(student.Age));
            Guard.Against.Null(student.Age, nameof(student.Age));
            Guard.Against.NullOrEmpty(student.Address, nameof(student.Address));
            Guard.Against.NullOrEmpty(student.Phone, nameof(student.Phone));
            Guard.Against.EnumOutOfRange(student.StateStudent, nameof(student.StateStudent));

            studentFound.SetIdentification(student.Identification);
            studentFound.SetName(student.Name);
            studentFound.SetLastName(student.LastName);
            studentFound.SetAge(student.Age);
            studentFound.SetAddress(student.Address);
            studentFound.SetPhone(student.Phone);
            studentFound.SetStateStudent(student.StateStudent);

            var studentUpdated = await _dbContext.SaveChangesAsync();

            student.SetStudentID(studentFound.StudentID);
            return studentUpdated == 0 ?
                throw new ApiException("The student was not updated.", StatusCodes.Status500InternalServerError) :
                student;
        }
    }
}