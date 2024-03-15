using MediatR;
using MicroserviceCase.Customer.Application.Commands;
using MicroserviceCase.Customer.Application.Dto;
using MicroserviceCase.Customer.Application.Mapping;
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
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Response<CreatedOrUpdatedCustomerDto>>
    {
        private readonly CustomerDbContext _context;

        public CreateCustomerCommandHandler(CustomerDbContext context)
        {
            _context = context;
        }
        public async Task<Response<CreatedOrUpdatedCustomerDto>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<CreatedOrUpdatedCustomerDto>();
            var customer = ObjectMapper.Mapper.Map<Domain.CustomerAggregate.Customer>(request);

            customer.Id = Guid.NewGuid();
            customer.CreatedAt = DateTime.UtcNow;

            _context.Add(customer);
            _context.SaveChanges();

            response.Data.CustomerId = customer.Id;
            return response;
        }
    }
}
