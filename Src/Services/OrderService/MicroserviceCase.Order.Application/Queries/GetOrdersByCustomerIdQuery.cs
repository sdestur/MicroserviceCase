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
    public class GetOrdersByCustomerIdQuery : IRequest<Response<List<OrderDto>>>
    {
        public GetOrdersByCustomerIdQuery(Guid customerId)
        {
            CustomerId = customerId;
        }

        [Required] public Guid CustomerId { get; set; }
    }
}
