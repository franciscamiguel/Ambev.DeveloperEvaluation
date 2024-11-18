using Ambev.DeveloperEvaluation.Domain.Models.CustomerAggregate.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.CustomerFeatures;

public class CreateCustomerProfile : Profile
{
    public CreateCustomerProfile()
    {
        CreateMap<CreateCustomerCommand, Customer>()
            .ReverseMap();
        CreateMap<Customer, CreateCustomerResult>()
            .ReverseMap();
    }
}