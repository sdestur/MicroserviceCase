using MediatR;
using MicroserviceCase.Customer.Application.Queries;
using MicroserviceCase.Customer.Infrustructure;
using MicroserviceCase.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroserviceCase.Customer.Application.Handlers
{
    public class ValidateCustomerQueryHandler : IRequestHandler<ValidateCustomerQuery, Response<bool>>
    {
        public CustomerDbContext _context;

        public ValidateCustomerQueryHandler(CustomerDbContext context)
        {
            _context = context;
        }

        public async Task<Response<bool>> Handle(ValidateCustomerQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            var customer = _context.Customers.FirstOrDefault(x => !x.IsDeleted && x.Id == request.CustomerId);
            if (customer is null) return response.AddError("Customer not found");

            return response.Success(true);
        }
    }
}
