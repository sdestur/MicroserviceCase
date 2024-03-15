using MicroserviceCase.Order.Infrustructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceeCase.Test.Unit.Customer.InitInstance
{
    public static class InitInstance
    {
        public static OrderDbContext InitOrderDbContextWithInMemoryCache()
        {
            var options = new DbContextOptionsBuilder<OrderDbContext>().UseInMemoryDatabase(databaseName: "Order").Options;

            var context = new OrderDbContext(options);

            return context;
        }
    }
}
