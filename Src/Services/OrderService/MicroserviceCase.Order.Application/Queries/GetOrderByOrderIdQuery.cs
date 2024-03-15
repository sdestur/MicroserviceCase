using MediatR;
using MicroserviceCase.Order.Application.Dto;
using MicroserviceCase.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceCase.Order.Application.Queries
{
    public class GetOrderByOrderIdQuery : IRequest<Response<OrderDto>>
    {
        public GetOrderByOrderIdQuery(Guid orderId)
        {
            OrderId = orderId;
        }

        [Required] public Guid OrderId { get; set; }
    }
}
