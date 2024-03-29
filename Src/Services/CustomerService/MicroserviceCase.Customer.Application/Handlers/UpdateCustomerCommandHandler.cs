﻿using MediatR;
using MicroserviceCase.Customer.Application.Commands;
using MicroserviceCase.Customer.Infrustructure;
using MicroserviceCase.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroserviceCase.Customer.Application.Handlers
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Response<bool>>
    {
        private CustomerDbContext _context;

        public UpdateCustomerCommandHandler(CustomerDbContext context)
        {
            _context = context;
        }

        public async Task<Response<bool>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            var customer = _context.Customers.FirstOrDefault(x => !x.IsDeleted && x.Id == request.Id);
            if (customer is null) return response.AddError("Customer not found");

            customer.Name = request.Name;
            customer.Address.AddressLine = request.Address.AddressLine;
            customer.Address.Country = request.Address.Country;
            customer.Address.CityCode = request.Address.CityCode;
            customer.Address.City = request.Address.City;

            _context.Customers.Update(customer);
            _context.SaveChanges();

            return response.Success(true);
        }
    }
}
