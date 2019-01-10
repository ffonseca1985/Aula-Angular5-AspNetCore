using Dapper;
using KeySystems.ERP.ContasAPagar.Core.DomainModel.Fornecedor;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace KeySystems.ERP.ContasAPagar.Core.Infraestructure.MysqlDapper.Repositories
{
    public class FornecedorRepository
    {
        private readonly IConfiguration _configuration;

        public FornecedorRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<Fornecedor> Get()
        {
            var cs = _configuration.GetConnectionString("keySystems");

            using (var connection = new MySqlConnection(cs))
            {
                var query = "select * from fornecedor";
                var result = connection.Query<Fornecedor>(query);

                return result;
            }
        }
    }
}
