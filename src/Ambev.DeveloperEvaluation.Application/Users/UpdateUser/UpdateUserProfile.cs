using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Users.UpdateUser;

public class UpdateUserProfile : Profile
{
    public UpdateUserProfile()
    {
        CreateMap<UpdateUserCommand, User>()
            .ReverseMap();

        CreateMap<User, UpdateUserResult>().ReverseMap();
    }
}