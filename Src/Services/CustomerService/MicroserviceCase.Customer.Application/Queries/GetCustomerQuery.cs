using MediatR;
using MicroserviceCase.Customer.Application.Dto;
using MicroserviceCase.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceCase.Customer.Application.Queries
{
    public class GetCustomerQuery : IRequest<Response<CustomerDto>>
    {
        public GetCustomerQuery(Guid id)
        {
            Id = id;
        }

        [Required] public Guid Id { get; set; }
    }
}
