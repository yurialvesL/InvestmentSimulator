using AutoMapper;
using InvestmentSimulator.Application.Commands.Users.GetUser;
using InvestmentSimulator.Controllers.Features.User.DTOs.GetUser;

namespace InvestmentSimulator.Controllers.Features.User.Mapping;

public class GetUserProfile : Profile
{
    public GetUserProfile()
    {
        CreateMap<GetUserRequest, GetUserCommand>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

        CreateMap<GetUserResult, GetUserResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserResult != null ? src.UserResult.Id : Guid.Empty))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserResult != null ? src.UserResult.Name : string.Empty))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.UserResult != null ? src.UserResult.Email : string.Empty))
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.UserResult != null ? src.UserResult.DateOfBirth : DateTime.MinValue))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.UserResult != null ? src.UserResult.CreatedAt : DateTime.MinValue))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UserResult != null ? src.UserResult.UpdatedAt : DateTime.MinValue));
    }
}
