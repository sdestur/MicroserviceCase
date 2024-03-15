using MediatR;
using MicroserviceCase.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceCase.Customer.Application.Queries
{
    public class ValidateCustomerQuery : IRequest<Response<bool>>
    {
        public ValidateCustomerQuery(Guid customerid)
        {
            CustomerId = customerid;
        }

        [Required] public Guid CustomerId { get; set; }
    }
}
