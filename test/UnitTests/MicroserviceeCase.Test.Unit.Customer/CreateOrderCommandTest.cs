using MicroserviceCase.Order.Application.Commands;
using MicroserviceCase.Order.Application.Dto;
using MicroserviceCase.Order.Application.Handlers;
using MicroserviceCase.Order.Infrustructure;
using System;
using System.Threading;
using Xunit;

namespace MicroserviceeCase.Test.Unit.Customer
{
    public class CreateOrderCommandTest
    {
        private readonly CreateOrderCommandHandler _handler;
        private OrderDbContext _context;
        private Mock<HttpRequest> _httpMock;

        public CreateOrderCommandTest()
        {
            _context = InitInstance.InitInstance.InitOrderDbContextWithInMemoryCache();
            _handler = new CreateOrderCommandHandler(_context);
            _httpMock = new Mock<HttpRequest>();
        }

        [Fact]
        public void CreateOrderCommand_SuccessfullyInsert_ReturnSuccessfulResponse()
        {

            var command = new CreateOrderCommand()
            {
                CustomerId = Guid.NewGuid(),
                Quantity = 1,
                Price = 1,
                Status = "in-way",
                Address = new AddressDto()
                {
                    AddressLine = "ANK",
                    Country = "ANKARA",
                    CityCode = 1,
                    City = "PURS"
                },
                ProductId = Guid.NewGuid()
            };

            var result = _handler.Handle(command, CancellationToken.None).Result;

            Assert.Equal(result.Errors, null);
            Assert.NotEqual(result.Data, null);

        }

        [Fact]
        public void CreateOrderCommand_CustomerNotValid_ReturnCustomerNotValidErrorResponse()
        {

            var command = new CreateOrderCommand()
            {
                CustomerId = Guid.NewGuid(),
                Quantity = 1,
                Price = 1,
                Status = "in-way",
                Address = new AddressDto()
                {

                    AddressLine = "ANK",
                    Country = "ANKARA",
                    CityCode = 1,
                    City = "PURS"
                },
                ProductId = Guid.NewGuid()
            };

            var result = _handler.Handle(command, CancellationToken.None).Result;

            Assert.Equal(result.Errors, null);
            Assert.NotEqual(result.Data, null);

        }
    }
}
