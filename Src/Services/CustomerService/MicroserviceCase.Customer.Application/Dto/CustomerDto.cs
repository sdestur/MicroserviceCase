using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceCase.Customer.Application.Dto
{
    public class CustomerDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public AddressDto Address { get; set; }
    }
}
