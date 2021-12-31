using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementPOC.DapperServices
{
    public class DapperContext 
    {
        
            private readonly IConfiguration _configuration;
            private readonly string _connectionString;
            public DapperContext(IConfiguration configuration)
            {
                _configuration = configuration;
                _connectionString = _configuration.GetConnectionString("DefaultConnection");
            }
            public IDbConnection CreateConnection()
                => new SqlConnection(_connectionString);
        
    }
}
