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
    public class CreateCustomerCommand : IRequest<Response<CreatedOrUpdatedCustomerDto>>
    {
        [Required] public string Name { get; set; }
        [Required] public string Email { get; set; }
        [Required] public AddressDto Address { get; set; }
    }
}
