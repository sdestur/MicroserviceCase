using AutoMapper;
using MicroserviceCase.Customer.Application.Commands;
using MicroserviceCase.Customer.Application.Dto;
using MicroserviceCase.Shared.Domain.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceCase.Customer.Application.Mapping
{
    internal class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<MicroserviceCase.Customer.Domain.CustomerAggregate.Customer, CustomerDto>().ReverseMap();
            CreateMap<MicroserviceCase.Customer.Domain.CustomerAggregate.Customer, CreateCustomerCommand>().ReverseMap().ForMember(x => x.Address, x => x.MapFrom(x => x.Address));
            CreateMap<AddressDto, Address>().ReverseMap();
        }
    }
}
