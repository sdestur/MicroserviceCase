using MicroserviceCase.Customer.Application.Commands;
using MicroserviceCase.Customer.Application.Handlers;
using MicroserviceCase.Customer.Infrustructure;
using MicroserviceCase.Order.Application.Commands;
using MicroserviceCase.Order.Application.Handlers;
using MicroserviceCase.Order.Domain.OrderAggregate;
using MicroserviceCase.Order.Infrustructure;
using System;
using System.Threading;
using Xunit;

namespace MicroserviceCase.Test.Intergration
{
    public class CreateCustomerAndBuyOrderIntegrationTest
    {
        private readonly CreateCustomerCommandHandler _customerHandler;
        private readonly CreateOrderCommandHandler _orderHandler;
        private CustomerDbContext _customerContext;
        private OrderDbContext _orderContext;
        public CreateCustomerAndBuyOrderIntegrationTest()
        {
            _customerContext = InitInstance.InitInstance.InitCustomerDbContextWithInMemoryCache();
            _orderContext = InitInstance.InitInstance.InitOrderDbContextWithInMemoryCache();
            _customerHandler = new CreateCustomerCommandHandler(_customerContext);
            _orderHandler = new CreateOrderCommandHandler(_orderContext);
        }
        [Fact]
        public void TeCreateCustomerAndBuyOrderIntegrationTestst()
        {
            var create_customer_command = new CreateCustomerCommand()
            {
                Email = "test@test.com",
                Name = "ayaz",
                Address = new AddressDto()
                {
                    AddressLine = "ANK",
                    Country = "ANKARA",
                    CityCode = 1,
                    City = "PURS"
                }
            };
            var customerid = _customerHandler.Handle(create_customer_command, CancellationToken.None).Result.Data.CustomerId;

            Assert.NotEqual(customerid, default);

            var create_order_command = new CreateOrderCommand()
            {
                CustomerId = Guid.NewGuid(),
                Quantity = 1,
                Price = 1,
                Status = "in-way",
                Address = new Order.Application.Dto.AddressDto()
                {
                    AddressLine = "IST",
                    Country = "ISTANBUL",
                    CityCode = 1,
                    City = "MACIDI"
                },
                ProductId = Guid.NewGuid()
            };

            var result = _orderHandler.Handle(create_order_command, CancellationToken.None).Result;

            Assert.Equal(result.Errors, null);
            Assert.NotEqual(result.Data, null);
        }
    }
}
