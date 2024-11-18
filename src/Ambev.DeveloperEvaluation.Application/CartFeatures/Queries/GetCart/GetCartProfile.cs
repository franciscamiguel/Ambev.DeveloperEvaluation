using Ambev.DeveloperEvaluation.Domain.Models.CartAggregate.Dtos;
using Ambev.DeveloperEvaluation.Domain.Models.CartAggregate.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.CartFeatures.Queries.GetCart;

public class GetCartProfile : Profile
{
    public GetCartProfile()
    {
        CreateMap<Cart, GetCartResult>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products))
            .ReverseMap();
        
        CreateMap<CartItem, CartItemDto>().ReverseMap();
    }
}