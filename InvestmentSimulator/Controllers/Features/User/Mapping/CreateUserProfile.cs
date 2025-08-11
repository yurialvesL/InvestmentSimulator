using AutoMapper;
using InvestmentSimulator.Application.Commands.Users.CreateUser;
using InvestmentSimulator.Controllers.Features.User.DTOs.CreateUser;

namespace InvestmentSimulator.Controllers.Features.User.Mapping;

public sealed class CreateUserProfile : Profile
{
    public CreateUserProfile()
    {
        CreateMap<CreateUserRequest,CreateUserCommand>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth));


        CreateMap<CreateUserResult, CreateUserResponse>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth));
    }
}
