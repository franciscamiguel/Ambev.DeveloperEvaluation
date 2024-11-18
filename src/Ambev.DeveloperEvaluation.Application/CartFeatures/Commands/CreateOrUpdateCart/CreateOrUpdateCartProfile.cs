using Ambev.DeveloperEvaluation.Domain.Models.CartAggregate.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.CartFeatures.Commands.CreateOrUpdateCart;

public class CreateOrUpdateCartProfile : Profile
{
    public CreateOrUpdateCartProfile()
    {
        CreateMap<Cart, CreateOrUpdateCartResult>().ReverseMap();
    }
}