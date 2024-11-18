using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.SaleFeatures.Queries;

public class GetSaleProfile : Profile
{
    public GetSaleProfile()
    {
        CreateMap<Sale, GetSaleResult>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
            .ReverseMap();
    }
}