using MicroserviceCase.Customer.Infrustructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceCase.Test.Unit.Order.InitInstance
{
    public static class InitInstance
    {
        public static CustomerDbContext InitCustomerDbContextWithInMemoryCache()
        {
            var options = new DbContextOptionsBuilder<CustomerDbContext>().UseInMemoryDatabase(databaseName: "customer").Options;

            var context = new CustomerDbContext(options);

            return context;
        }
    }
}
