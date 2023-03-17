using AutoMapper;
using HomeTask.Data.Entities;
using HomeTask.Dtos;

namespace HomeTask.Mapping
{
    public class AppMapping : Profile
    {
        public AppMapping()
        {
            CreateMap<Employee, EmployeeDto>();

            //Create
            CreateMap<Employee,EmployeeDto>().ReverseMap();
            CreateMap<Employee,EmployeeUpdateDto>().ReverseMap();
        }
    }
}
