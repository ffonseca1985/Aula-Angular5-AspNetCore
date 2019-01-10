using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using KeySystems.ERP.ContasAPagar.Core.DomainModel.ContasAPagar;
using Microsoft.Extensions.Configuration;

namespace KeySystems.ERP.ContasAPagar.Core.Infraestructure.MysqlDapper.Repositories
{
    public class TipoTituloRepository :
        RepositoryBase
    {
        public TipoTituloRepository(IConfiguration configuration)
            : base(configuration) {}

        public List<TipoTitulo> Get()
        {
            using (var connection = base.MySqlConnection())
            {
                var query = "select * from tipoTitulo";
                return connection.Query<TipoTitulo>(query).ToList();
            }
        }
    }
}
