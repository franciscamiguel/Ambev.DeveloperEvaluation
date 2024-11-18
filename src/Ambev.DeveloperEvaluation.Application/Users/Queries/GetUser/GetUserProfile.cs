using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Users.Queries.GetUser;

/// <summary>
///     Profile for mapping between User entity and GetUserResponse
/// </summary>
public class GetUserProfile : Profile
{
    /// <summary>
    ///     Initializes the mappings for GetUser operation
    /// </summary>
    public GetUserProfile()
    {
        CreateMap<User, GetUserResult>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Username))
            .ReverseMap();
    }
}