using MicroserviceCase.Customer.Infrustructure;
using MicroserviceCase.Order.Infrustructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceCase.Test.Intergration.InitInstance
{
    public static class InitInstance
    {
        public static CustomerDbContext InitCustomerDbContextWithInMemoryCache()
        {
            var options = new DbContextOptionsBuilder<CustomerDbContext>().UseInMemoryDatabase(databaseName: "customer").Options;

            var context = new CustomerDbContext(options);

            return context;
        }
        public static OrderDbContext InitOrderDbContextWithInMemoryCache()
        {
            var options = new DbContextOptionsBuilder<OrderDbContext>().UseInMemoryDatabase(databaseName: "order").Options;

            var context = new OrderDbContext(options);

            return context;
        }
    }
}
