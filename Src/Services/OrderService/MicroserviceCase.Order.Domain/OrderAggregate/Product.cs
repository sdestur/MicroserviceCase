using MicroserviceCase.Shared.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceCase.Order.Domain.OrderAggregate
{
    public class Product : Entity, IAggregateRoot
    {
        [Required] public string IamgeUrl { get; set; }
        [Required] public string Name { get; set; }
    }
}
