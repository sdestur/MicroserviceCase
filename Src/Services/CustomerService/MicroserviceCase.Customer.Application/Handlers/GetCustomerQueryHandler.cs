using MediatR;
using MicroserviceCase.Customer.Application.Dto;
using MicroserviceCase.Customer.Application.Mapping;
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
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, Response<CustomerDto>>
    {
        public CustomerDbContext _context;

        public GetCustomerQueryHandler(CustomerDbContext context)
        {
            _context = context;
        }

        public async Task<Response<CustomerDto>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<CustomerDto>();

            var customer = _context.Customers.FirstOrDefault(x => !x.IsDeleted && x.Id == request.Id);
            if (customer is null) return response.AddError("Customer not found");

            response.Data = ObjectMapper.Mapper.Map<CustomerDto>(customer);

            return response;
        }
    }
}
