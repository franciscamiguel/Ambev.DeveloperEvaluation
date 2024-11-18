using Ambev.DeveloperEvaluation.Domain.Models.ProductAggregate.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.ProductFeatures;

public class CreateProductProfile : Profile
{
    public CreateProductProfile()
    {
        CreateMap<CreateProductCommand, Product>()
            .ReverseMap();
        CreateMap<Product, CreateProductResult>()
            .ReverseMap();
    }
}