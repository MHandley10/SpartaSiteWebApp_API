using AutoMapper;
using SpartaSiteWebApp_API.Models.Domain;
using SpartaSiteWebApp_API.Models.DTO.CareerItemDTOs;
using SpartaSiteWebApp_API.Models.DTO.CourseDTOs;

namespace SpartaSiteWebApp_API
{
    public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<CareerItem, CreateCareerItemDTO>().ReverseMap();
			CreateMap<CareerItem, UpdateCareerItemDTO>().ReverseMap();
			CreateMap<CareerItem, CareerItemDTO>().ReverseMap();
			CreateMap<Course, CourseDTO>().ReverseMap();
		}
	}
}
