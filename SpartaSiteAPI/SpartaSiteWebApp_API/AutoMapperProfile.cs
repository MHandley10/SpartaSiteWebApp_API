using AutoMapper;
using SpartaSiteWebApp_API.Models.Domain;
using SpartaSiteWebApp_API.Models.DTO.CareerItemDTOs;
using SpartaSiteWebApp_API.Models.DTO.CourseDTOs;
using SpartaSiteWebApp_API.Models.DTO.EnquiringCopmanyDTOs;
using SpartaSiteWebApp_API.Models.DTO.NewsItemDTOs;
using SpartaSiteWebApp_API.Models.DTO.QuestionDTOs;
using SpartaSiteWebApp_API.Models.DTO.SpartanDTOs;
using SpartaSiteWebApp_API.Models.DTO.UserDTOs;

namespace SpartaSiteWebApp_API;

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
		CreateMap<Spartan, SpartanDTO>().ReverseMap();
		CreateMap<Spartan, CreateSpartanDTO>().ReverseMap();
		CreateMap<Spartan, UpdateSpartanDTO>().ReverseMap();
		CreateMap<User, UserDTO>().ReverseMap();
		CreateMap<User, CreateUserDTO>().ReverseMap();
		CreateMap<User, UpdateUserDTO>().ReverseMap();
		CreateMap<NewsItem, NewsItemDTO>().ReverseMap();
		CreateMap<NewsItem, UpdateNewsItemDTO>().ReverseMap();
		CreateMap<Question, QuestionDTO>().ReverseMap();
		CreateMap<Question, UpdateQuestionDTO>().ReverseMap();
	}
}
