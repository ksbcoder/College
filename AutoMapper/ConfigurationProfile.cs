using AutoMapper;
using College.Domain.Commands.Student;
using College.Domain.Commands.Subject;
using College.Domain.Commands.Teacher;
using College.Domain.DTO.Subject;
using College.Domain.Entities;

namespace College.AutoMapper
{
    public class ConfigurationProfile : Profile
    {
        public ConfigurationProfile()
        {
            #region Teacher
            CreateMap<CreateTeacherCmd, Teacher>().ReverseMap();
            CreateMap<UpdateTeacherCmd, Teacher>().ReverseMap();
            #endregion

            #region Student
            CreateMap<CreateStudentCmd, Student>().ReverseMap();
            CreateMap<UpdateStudentCmd, Student>().ReverseMap();
            #endregion

            #region Subject
            CreateMap<CreateSubjectCmd, Subject>().ReverseMap();
            CreateMap<SubjectDTO, Subject>().ReverseMap();
            //CreateMap<UpdateSubjectCmd, Subject>().ReverseMap();
            #endregion
        }
    }
}