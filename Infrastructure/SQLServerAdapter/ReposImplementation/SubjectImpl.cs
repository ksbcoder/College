using Ardalis.GuardClauses;
using AutoMapper;
using College.Business.IRepositories;
using College.Domain.DTO.Subject;
using College.Domain.Entities;
using College.Infrastructure.SQLServerAdapter.Gateway;
using College.Wrappers;
using Microsoft.EntityFrameworkCore;
using static College.Domain.Common.Enums;

namespace College.Infrastructure.SQLServerAdapter.ReposImplementation
{
    public class SubjectImpl : ISubject
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public SubjectImpl(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<SubjectDTO> AssignToTeacherAsync(int code, string teacherID)
        {
            var subject = await _dbContext.Subjects.FirstOrDefaultAsync(s => s.Code == code
                                && s.StateSubject == StateSubject.Active)
                ?? throw new ApiException("The subject was not found, maybe was eliminated already.", StatusCodes.Status404NotFound);

            subject.SetTeacherID(Guid.Parse(teacherID));

            var subjectUpdated = await _dbContext.SaveChangesAsync();
            return subjectUpdated == 0 ?
                throw new ApiException("The subject was not updated.", StatusCodes.Status500InternalServerError) :
                _mapper.Map<SubjectDTO>(subject);
        }

        public async Task<SubjectDTO> CreateSubjectAsync(Subject subject)
        {
            Subject.SetDetailsToSubject(subject);

            Guard.Against.Null(subject, nameof(subject));
            Guard.Against.NullOrEmpty(subject.TeacherID.ToString(), nameof(subject.TeacherID));
            Guard.Against.NullOrEmpty(subject.Name, nameof(subject.Name));
            Guard.Against.EnumOutOfRange(subject.StateSubject, nameof(subject.StateSubject));
            Guard.Against.Null(subject.StateSubject, nameof(subject.StateSubject));

            _dbContext.Subjects.Add(subject);

            var subjectCreated = await _dbContext.SaveChangesAsync();

            return subjectCreated == 0 ?
                throw new ApiException("The subject was not created.", StatusCodes.Status500InternalServerError) :
                _mapper.Map<SubjectDTO>(subject);
        }

        public async Task<List<SubjectDTO>> GetAllSubjectsAsync()
        {
            var subjects = await _dbContext.Subjects.Where(s => s.StateSubject == StateSubject.Active).ToListAsync();
            return subjects.Count == 0 ?
                throw new ApiException("There are not subjects.", StatusCodes.Status404NotFound) :
                _mapper.Map<List<SubjectDTO>>(subjects);
        }

        public async Task<SubjectDTO> GetSubjectByIdAsync(int code)
        {
            var subject = await _dbContext.Subjects.FirstOrDefaultAsync(s => s.Code == code
                                && s.StateSubject == StateSubject.Active)
                ?? throw new ApiException("The subject was not found, maybe was eliminated already.", StatusCodes.Status404NotFound);

            return _mapper.Map<SubjectDTO>(subject);
        }
    }
}