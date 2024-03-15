using MediatR;
using MicroserviceCase.Order.Application.Commands;
using MicroserviceCase.Order.Infrustructure;
using MicroserviceCase.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroserviceCase.Order.Application.Handlers
{
    public class ChangeStatusOrderCommandHandler : IRequestHandler<ChangeStatusOrderCommand, Response<bool>>
    {
        private readonly OrderDbContext _context;

        public ChangeStatusOrderCommandHandler(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<Response<bool>> Handle(ChangeStatusOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            var order = await _context.Orders.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.OrderId);
            if (order == default) return response.AddError("order not found");

            order.Status = request.Status;

            _context.Orders.Update(order);
            _context.SaveChanges();

            return response.Success(true);
        }
    }
}
