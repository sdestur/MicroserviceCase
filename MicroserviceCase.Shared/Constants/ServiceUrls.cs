using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceCase.Shared.Constants
{
    public static class ServiceUrls
    {
        public static string Gateway => "localhost:5000";
        public static string Order => "localhost:5011";
        public static string Customer => "http://localhost:5010/api/customers/";
    }
}
