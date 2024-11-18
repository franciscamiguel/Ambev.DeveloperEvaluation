using Ambev.DeveloperEvaluation.Application.CartFeatures.Commands.CreateOrUpdateCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateOrUpdateCart;

public class CreateOrUpdateCartProfile : Profile
{
    public CreateOrUpdateCartProfile()
    {
        CreateMap<CartItemRequest, AddOrUpdateCartItemCommand>().ReverseMap();
    }
}