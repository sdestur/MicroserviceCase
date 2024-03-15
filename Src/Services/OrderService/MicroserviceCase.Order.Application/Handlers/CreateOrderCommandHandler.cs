using MediatR;
using MicroServiceCase.FastHttp.Enum;
using MicroServiceCase.FastHttp;
using MicroserviceCase.Order.Application.Commands;
using MicroserviceCase.Order.Application.Dto;
using MicroserviceCase.Order.Infrustructure;
using MicroserviceCase.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MicroserviceCase.Shared.Dtos;
using MicroserviceCase.Order.Application.Mapping;

namespace MicroserviceCase.Order.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<OrderDto>>
    {
        private readonly OrderDbContext _context;

        public CreateOrderCommandHandler(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<Response<OrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<OrderDto>();


            var req = new HttpRequest(ServiceUrls.Customer + "validate/" + request.CustomerId.ToString())
                .SetHttpMethod(HttpMethodTypes.POST).SetDataFormat(HttpDataFormatTypes.Json);

            var customerIsValidate = await req.ExecuteAsync<Response<bool>>();

            if (!customerIsValidate.Data) return response.AddError("Customer not found");

            var product = _context.Products.FirstOrDefault(x => !x.IsDeleted && request.ProductId == x.Id);

            if (product == default) return response.AddError("Product not found");

            Domain.OrderAggregate.Order order = ObjectMapper.Mapper.Map<Domain.OrderAggregate.Order>(request);

            order.CreatedAt = DateTime.UtcNow;
            order.Id = Guid.NewGuid();

            _context.Orders.Add(order);
            _context.SaveChanges();

            var orderdto = ObjectMapper.Mapper.Map<OrderDto>(order);
            orderdto.Product = ObjectMapper.Mapper.Map<ProductDto>(product);

            return response.Success(orderdto);
        }
    }
}
