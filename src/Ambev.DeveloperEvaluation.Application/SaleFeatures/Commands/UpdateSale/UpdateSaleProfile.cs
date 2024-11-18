using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.SaleFeatures.Commands.UpdateSale;

public class UpdateSaleProfile : Profile
{
    public UpdateSaleProfile()
    {
        CreateMap<UpdateSaleCommand, Sale>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
            .ReverseMap();

        CreateMap<Sale, UpdateSaleResult>().ReverseMap();
    }
}