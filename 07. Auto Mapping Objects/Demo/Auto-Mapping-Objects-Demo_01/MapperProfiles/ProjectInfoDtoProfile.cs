using AutoMapper;
using Auto_Mapping_Objects_Demo_01.Data.Models;

namespace Auto_Mapping_Objects_Demo_01.MapperProfiles
{
    public class ProjectInfoDtoProfile : Profile
    {
        public ProjectInfoDtoProfile()
        {
            this.CreateMap<Project, ProjectInfo>();
        }
    }
}
