using MediatR;
using MicroserviceCase.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceCase.Customer.Application.Commands
{
    public class RemoveCustomerCommand : IRequest<Response<bool>>
    {
        public RemoveCustomerCommand(Guid id)
        {
            Id = id;
        }

        [Required] public Guid Id { get; set; }
    }
}
