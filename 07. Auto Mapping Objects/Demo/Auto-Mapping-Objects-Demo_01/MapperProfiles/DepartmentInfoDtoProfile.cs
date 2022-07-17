using AutoMapper;
using Auto_Mapping_Objects_Demo_01.Data.Models;

namespace Auto_Mapping_Objects_Demo_01.MapperProfiles
{
    public class DepartmentInfoDtoProfile : Profile
    {
        public DepartmentInfoDtoProfile()
        {
            this.CreateMap<Department, DepartmentInfo>()
                      .ForMember(x => x.Manager, options =>
                      options.MapFrom(x => $"{x.Manager.FirstName} {x.Manager.LastName}")); // Custom Mapping 
        }
    }
}
