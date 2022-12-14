using AutoMapper;
using USP.Data;
using USP.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace USP.Services;

public class MapperService : Profile
{
    public MapperService()
    {
        //product model
        CreateMap<ProductModel, Product>().ReverseMap();
        CreateMap<CommentModel, Comment>().ReverseMap();
        CreateMap<WorkModel, Work>().ReverseMap();
        //category model
        CreateMap<CategoryModel, Category>().ReverseMap();
        //category model to select list 
        CreateMap<CategoryModel, SelectListItem>()
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Name));
        //typemodel to select list
        CreateMap<TypeModel, SelectListItem>()
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Type));
        //registration model to user
        CreateMap<RegistrationModel, User>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
        //login model to user
        CreateMap<LoginModel, User>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
    }
}