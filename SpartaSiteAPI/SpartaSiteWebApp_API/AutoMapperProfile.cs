using AutoMapper;
using SpartaSiteWebApp_API.Models.Domain;
using SpartaSiteWebApp_API.Models.DTO.CareerItemDTOs;
using SpartaSiteWebApp_API.Models.DTO.CourseDTOs;
using SpartaSiteWebApp_API.Models.DTO.EnquiringCopmanyDTOs;

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
			CreateMap<EnquiringCompany, EnquiringCompanyDTO>().ReverseMap();
			CreateMap<EnquiringCompany, CreateEnquiringCompanyDTO>().ReverseMap();
			CreateMap<EnquiringCompany, UpdateEnquiringCompanyDTO>().ReverseMap();
		}
	}
}
