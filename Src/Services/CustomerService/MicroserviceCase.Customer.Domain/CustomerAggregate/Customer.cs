using MicroserviceCase.Shared.Domain.Core;
using MicroserviceCase.Shared.Domain.Core.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceCase.Customer.Domain.CustomerAggregate
{
    public class Customer : Entity, IAggregateRoot
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public Address Address { get; set; }
    }
}
