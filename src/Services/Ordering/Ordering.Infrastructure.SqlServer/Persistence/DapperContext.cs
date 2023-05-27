using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.SqlServer.Persistence
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            CreateConnection();
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_configuration.GetConnectionString("OrderingConnectionString"));
    }
}
