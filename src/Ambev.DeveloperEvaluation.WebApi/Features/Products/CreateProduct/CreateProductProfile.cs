using Ambev.DeveloperEvaluation.Application.ProductFeatures;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public class CreateProductProfile : Profile
{
    public CreateProductProfile()
    {
        CreateMap<CreateProductRequest, CreateProductCommand>().ReverseMap();
        CreateMap<CreateProductResult, CreateProductResponse>().ReverseMap();
    }
}