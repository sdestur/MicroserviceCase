using MediatR;
using MicroserviceCase.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceCase.Order.Application.Commands
{
    public class ChangeStatusOrderCommand : IRequest<Response<bool>>
    {

        [Required] public Guid OrderId { get; set; }
        [Required] public string Status { get; set; }
    }
}
