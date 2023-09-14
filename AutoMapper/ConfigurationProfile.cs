using AutoMapper;
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
        }
    }
}
