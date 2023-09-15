using Ardalis.GuardClauses;
using AutoMapper;
using College.Business.IRepositories;
using College.Domain.DTO.SubjectEnrollments;
using College.Domain.Entities;
using College.Infrastructure.SQLServerAdapter.Gateway;
using College.Wrappers;
using Microsoft.EntityFrameworkCore;
using static College.Domain.Common.Enums;

namespace College.Infrastructure.SQLServerAdapter.ReposImplementation
{
    public class SubjectEnrollmentImpl : ISubjectEnrollment
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public SubjectEnrollmentImpl(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<SubjectEnrollmentDTO> AssignToStudentAsync(SubjectEnrollment subjectEnrollment)
        {
            var studentFound = await _dbContext.Students.FirstOrDefaultAsync
                                        (s => s.StudentID == subjectEnrollment.StudentID
                                        && s.StateStudent == StateStudent.Active)
                ?? throw new ApiException("The student was not found, maybe was eliminated already.", StatusCodes.Status404NotFound);

            var subjectFound = await _dbContext.Subjects.FirstOrDefaultAsync
                                        (s => s.Code == subjectEnrollment.SubjectCode
                                        && s.StateSubject == StateSubject.Active)
                ?? throw new ApiException("The subject was not found, maybe was eliminated already.", StatusCodes.Status404NotFound);

            var enrollmentOld = await GetEnrollmentsByIDsAsync(subjectEnrollment.SubjectCode, subjectEnrollment.StudentID.ToString());

            if (enrollmentOld.Count != 0)
            {
                foreach (SubjectEnrollmentDTO enrollment in enrollmentOld)
                {
                    if (enrollment.AcademicYear == subjectEnrollment.AcademicYear)
                    {
                        throw new ApiException("The student is already enrolled in this subject this year.",
                                StatusCodes.Status400BadRequest);
                    }
                }
            }

            SubjectEnrollment.SetDetailsToEnrollment(subjectEnrollment);

            Guard.Against.Null(subjectEnrollment, nameof(subjectEnrollment));
            Guard.Against.NullOrEmpty(subjectEnrollment.StudentID, nameof(subjectEnrollment.StudentID));
            Guard.Against.NullOrEmpty(subjectEnrollment.SubjectCode.ToString(), nameof(subjectEnrollment.SubjectCode));
            Guard.Against.Negative(subjectEnrollment.FinalMark, nameof(subjectEnrollment.FinalMark));
            Guard.Against.NullOrEmpty(subjectEnrollment.EnrollmentRegister.ToString(), nameof(subjectEnrollment.EnrollmentRegister));
            Guard.Against.NullOrEmpty(subjectEnrollment.AcademicYear.ToString(), nameof(subjectEnrollment.AcademicYear));
            Guard.Against.EnumOutOfRange(subjectEnrollment.StateEnrollment, nameof(subjectEnrollment.StateEnrollment));

            _dbContext.SubjectEnrollments.Add(subjectEnrollment);

            var subjectEnrollmentCreated = await _dbContext.SaveChangesAsync();

            return subjectEnrollmentCreated == 0 ?
                throw new ApiException("The subject enrollment was not created.", StatusCodes.Status500InternalServerError) :
                _mapper.Map<SubjectEnrollmentDTO>(subjectEnrollment);
        }

        public async Task<SubjectEnrollmentDTO> GetByIDsAsync(int code, string studentID)
        {
            var subjectEnrollment = await _dbContext.SubjectEnrollments.FirstOrDefaultAsync(se => se.SubjectCode == code
                                           && se.StudentID == Guid.Parse(studentID)
                                           && se.StateEnrollment == StateSubjectEnrollment.Active);

            return _mapper.Map<SubjectEnrollmentDTO>(subjectEnrollment);
        }

        public async Task<List<SubjectEnrollmentDTO>> GetEnrollmentsByIDsAsync(int? code, string studentID)
        {
            var query = _dbContext.SubjectEnrollments.Where(se => se.StudentID.ToString() == studentID
                 && se.StateEnrollment == StateSubjectEnrollment.Active);

            if (code.HasValue)
                query = query.Where(se => se.SubjectCode == code);

            var subjectEnrollments = await query.ToListAsync();

            return _mapper.Map<List<SubjectEnrollmentDTO>>(subjectEnrollments);
        }
    }
}