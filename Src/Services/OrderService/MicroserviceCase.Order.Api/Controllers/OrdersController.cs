using MicroserviceCase.Order.Application.Commands;
using MicroserviceCase.Order.Application.Dto;
using MicroserviceCase.Order.Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using MediatR;
using MicroserviceCase.Shared.Dtos;

namespace MicroserviceCase.Order.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<Response<List<OrderDto>>> GetAll()
        {
            return _mediator.Send(new GetAllOrderQuery());
        }
        [HttpGet("{id}")]
        public Task<Response<OrderDto>> GetByOrderId([FromRoute] Guid id)
        {
            return _mediator.Send(new GetOrderByOrderIdQuery(id));
        }
        [HttpGet("customerorders/{customerid}")]
        public Task<Response<List<OrderDto>>> GetByCustomerId([FromRoute] Guid customerid)
        {
            return _mediator.Send(new GetOrdersByCustomerIdQuery(customerid));
        }

        [HttpPost]
        public Task<Response<OrderDto>> Create(CreateOrderCommand request)
        {
            return _mediator.Send(request);
        }
        [HttpPut]
        public Task<Response<bool>> Update(UpdateOrderCommand request)
        {
            return _mediator.Send(request);
        }

        [HttpDelete("{id}")]
        public Task<Response<bool>> Delete([FromRoute] Guid id)
        {
            return _mediator.Send(new DeleteOrderCommand(id));
        }

        [HttpPost("changestatus")]
        public Task<Response<bool>> CahangeStatus([FromBody] ChangeStatusOrderCommand request)
        {
            return _mediator.Send(request);
        }
    }
}
