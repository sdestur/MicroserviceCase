using MicroserviceCase.Shared.Domain.Core.Entites;
using MicroserviceCase.Shared.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceCase.Order.Domain.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        [Required] public Guid CustomerId { get; set; }
        [Required] public int Quantity { get; set; }
        [Required] public double Price { get; set; }
        [Required] public string Status { get; set; }
        public Address Address { get; set; }
        public Product Product { get; set; }
        [ForeignKey("Product")][Required] public Guid ProductId { get; set; }
    }
}
