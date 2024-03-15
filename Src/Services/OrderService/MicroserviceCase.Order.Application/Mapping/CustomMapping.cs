using AutoMapper;
using MicroserviceCase.Order.Application.Commands;
using MicroserviceCase.Order.Application.Dto;
using MicroserviceCase.Order.Domain.OrderAggregate;
using MicroserviceCase.Shared.Domain.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceCase.Order.Application.Mapping
{
    public class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<MicroserviceCase.Order.Domain.OrderAggregate.Order, OrderDto>().ReverseMap();
            CreateMap<MicroserviceCase.Order.Domain.OrderAggregate.Order, CreateOrderCommand>().ReverseMap().ForMember(x => x.Address, x => x.MapFrom(x => x.Address));
            CreateMap<AddressDto, Address>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
        }
    }
}
