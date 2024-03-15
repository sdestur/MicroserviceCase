using MediatR;
using MicroserviceCase.Customer.Application.Dto;
using MicroserviceCase.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceCase.Order.Application.Commands
{
    public class CreateOrderCommand : IRequest<Response<OrderDto>>
    {
        [Required] public Guid CustomerId { get; set; }
        [Required] public int Quantity { get; set; }
        [Required] public double Price { get; set; }
        [Required] public string Status { get; set; }
        [Required] public AddressDto Address { get; set; }
        [Required] public Guid ProductId { get; set; }
    }
}
