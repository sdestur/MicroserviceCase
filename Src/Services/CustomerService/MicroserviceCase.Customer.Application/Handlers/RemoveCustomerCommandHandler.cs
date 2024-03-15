using MediatR;
using MicroserviceCase.Customer.Application.Commands;
using MicroserviceCase.Customer.Infrustructure;
using MicroserviceCase.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroserviceCase.Customer.Application.Handlers
{
    public class RemoveCustomerCommandHandler : IRequestHandler<RemoveCustomerCommand, Response<bool>>
    {
        public CustomerDbContext _context;

        public RemoveCustomerCommandHandler(CustomerDbContext context)
        {
            _context = context;
        }

        public async Task<Response<bool>> Handle(RemoveCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            var customer = await _context.Customers.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.Id);
            if (customer is null) return response.AddError("Customer not found");

            customer.IsDeleted = true;

            _context.Customers.Update(customer);
            _context.SaveChanges();

            return response.Success(true);
        }
    }
}
