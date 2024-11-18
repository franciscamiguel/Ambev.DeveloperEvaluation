using Ambev.DeveloperEvaluation.Application.SaleFeatures.Commands.UpdateSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

public class UpdateSaleProfile : Profile
{
    public UpdateSaleProfile()
    {
        CreateMap<UpdateSaleRequest, UpdateSaleCommand>().ReverseMap();
        CreateMap<UpdateSaleResult, UpdateSaleResponse>().ReverseMap();
    }
}