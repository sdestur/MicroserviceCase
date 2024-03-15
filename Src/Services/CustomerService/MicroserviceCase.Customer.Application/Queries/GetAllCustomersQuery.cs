using MediatR;
using MicroserviceCase.Customer.Application.Dto;
using MicroserviceCase.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceCase.Customer.Application.Queries
{
    public class GetAllCustomersQuery : IRequest<Response<List<CustomerDto>>>
    {

    }
}
