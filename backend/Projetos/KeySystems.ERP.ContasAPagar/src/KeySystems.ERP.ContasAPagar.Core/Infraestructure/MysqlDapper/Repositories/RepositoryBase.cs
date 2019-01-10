using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace KeySystems.ERP.ContasAPagar.Core.Infraestructure.MysqlDapper.Repositories
{
    public class RepositoryBase
    {
        private readonly IConfiguration _configuration;

        public RepositoryBase(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public MySqlConnection MySqlConnection()
        {
            var cs = _configuration.GetConnectionString("keySystems");
            return new MySqlConnection(cs);
        }
    }
}
