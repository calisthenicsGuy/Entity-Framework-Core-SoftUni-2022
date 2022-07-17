using AutoMapper;
using Auto_Mapping_Objects_Demo_01.Data.Models;

namespace Auto_Mapping_Objects_Demo_01.MapperProfiles
{
    public class EmployeeInfoDtoProfile : Profile
    {
        public EmployeeInfoDtoProfile()
        {
            this.CreateMap<Employee, EmployeeInfo>();
        }
    }
}
