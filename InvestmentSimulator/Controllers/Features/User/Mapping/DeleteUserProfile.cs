using AutoMapper;
using InvestmentSimulator.Application.Commands.Users.DeleteUser;
using InvestmentSimulator.Controllers.Features.User.DTOs.DeleteUser;

namespace InvestmentSimulator.Controllers.Features.User.Mapping
{
    public class DeleteUserProfile : Profile
    {
        public DeleteUserProfile()
        {
            CreateMap<DeleteUserRequest,DeleteUserCommand>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
        }
    }
}
