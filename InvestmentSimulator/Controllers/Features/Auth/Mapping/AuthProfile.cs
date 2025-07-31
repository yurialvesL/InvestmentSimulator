using AutoMapper;
using InvestmentSimulator.Application.Commands.Auth;
using InvestmentSimulator.Controllers.Features.Auth.DTOs;

namespace InvestmentSimulator.Controllers.Features.Auth.Mapping;

public sealed class AuthProfile : Profile
{
    public AuthProfile() // Add a constructor to define the mapping
    {
        CreateMap<AuthRequest, AuthenticateUserCommand>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

        CreateMap<AuthenticateUserResult, AuthResponse>()
            .ForMember(dest => dest.Token, opt => opt.MapFrom(src => src.Token))
            .ForMember(dest => dest.RefreshToken, opt => opt.MapFrom(src => src.RefreshToken))
            .ForMember(dest => dest.RefreshTokenExpiresAt, opt => opt.MapFrom(src => src.RefreshTokenExpiresAt))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.ExpiresAt, opt => opt.MapFrom(src => src.ExpiresAt));
    }
}
