using MediatR;
using MicroserviceCase.Customer.Application.Dto;
using MicroserviceCase.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceCase.Customer.Application.Commands
{
    public class UpdateCustomerCommand : IRequest<Response<bool>>
    {
        [Required] public Guid Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public AddressDto Address { get; set; }
    }
}
