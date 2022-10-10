using AutoMapper;
using USP.Data;
using USP.Models;

namespace USP.Services;

public class MapperService : Profile
{

    public MapperService()
    {
        CreateMap<ProductModel, Product>().ReverseMap();
        
        
        CreateMap<UserModel, User>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + "" + src.LastName));
    }
    
}