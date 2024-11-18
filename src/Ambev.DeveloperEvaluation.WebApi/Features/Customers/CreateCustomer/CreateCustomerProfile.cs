using Ambev.DeveloperEvaluation.Application.CustomerFeatures;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer;

public class CreateCustomerProfile : Profile
{
    public CreateCustomerProfile()
    {
        CreateMap<CreateCustomerRequest, CreateCustomerCommand>()
            .ForMember(dest => dest.UserCommand, opt => opt.MapFrom(src => src.UserRequest));
        CreateMap<CreateCustomerResult, CreateCustomerResponse>().ReverseMap();
    }
}