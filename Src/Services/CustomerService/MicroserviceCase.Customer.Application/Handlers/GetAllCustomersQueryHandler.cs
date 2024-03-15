using MediatR;
using MicroserviceCase.Customer.Application.Dto;
using MicroserviceCase.Customer.Application.Mapping;
using MicroserviceCase.Customer.Application.Queries;
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
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, Response<List<CustomerDto>>>
    {
        public CustomerDbContext _context;

        public GetAllCustomersQueryHandler(CustomerDbContext context)
        {
            _context = context;
        }
        public async Task<Response<List<CustomerDto>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<List<CustomerDto>>();
            var customers = await _context.Customers.Where(x => !x.IsDeleted).ToListAsync();
            var customerdto = ObjectMapper.Mapper.Map<List<CustomerDto>>(customers);
            response.Data = customerdto;
            return response;
        }
    }
}
