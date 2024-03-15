using System;
using Xunit;

namespace MicroserviceCase.Test.Unit.Order
{
    public class CreateCustomerTest
    {
        private readonly CreateCustomerCommandHandler _handler;
        private CustomerDbContext _context;
        public CreateCustomerTest()
        {
            _context = InitInstance.InitInstance.InitCustomerDbContextWithInMemoryCache();
            _handler = new CreateCustomerCommandHandler(_context);
        }
        [Fact]
        public void CreateCustomerCommand_SuccessfullyInsert_ReturnSuccessfulResponse()
        {
            var command = new CreateCustomerCommand()
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
            var result = _handler.Handle(command, CancellationToken.None).Result;

            Assert.Equal(result.Errors, null);
            Assert.NotEqual(result.Data.CustomerId, default);

            var customer = _context.Customers.FirstOrDefault(x => x.Id == result.Data.CustomerId);

            Assert.NotEqual(customer, null);
        }
    }
}
