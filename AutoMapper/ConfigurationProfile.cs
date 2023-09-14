using AutoMapper;
using College.Domain.Commands.Student;
using College.Domain.Commands.Teacher;
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
        }
    }
}
