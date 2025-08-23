using AutoMapper;
using InvestmentSimulator.Application.Commands.Users.GetAllUsers;
using InvestmentSimulator.Controllers.Features.User.DTOs.GetAllUsers;
using InvestmentSimulator.Controllers.Features.User.DTOs.GetUser;


namespace InvestmentSimulator.Controllers.Features.User.Mapping;

public class GetAllUsersProfile :Profile
{
    public GetAllUsersProfile()
    {
        CreateMap<GetAllUsersResult, GetAllUsersResponse>()
            .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users != null ? src.Users.Select(user => new GetUserResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            }).ToList() : null));
    }
}
