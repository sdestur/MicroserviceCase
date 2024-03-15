using MediatR;
using MicroserviceCase.Order.Application.Dto;
using MicroserviceCase.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceCase.Order.Application.Queries
{
    public class GetAllOrderQuery : IRequest<Response<List<OrderDto>>>
    {

    }
}
