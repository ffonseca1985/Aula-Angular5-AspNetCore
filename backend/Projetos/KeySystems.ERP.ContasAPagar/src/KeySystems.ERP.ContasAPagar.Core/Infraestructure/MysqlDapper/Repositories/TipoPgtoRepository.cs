using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using KeySystems.ERP.ContasAPagar.Core.DomainModel.ContasAPagar;
using Microsoft.Extensions.Configuration;

namespace KeySystems.ERP.ContasAPagar.Core.Infraestructure.MysqlDapper.Repositories
{
    public class TipoPgtoRepository :
        RepositoryBase
    {
        public TipoPgtoRepository(IConfiguration configuration) 
            : base(configuration)
        {
        }

        public List<TipoPgto> Get()
        {
            using (var connection = base.MySqlConnection())
            {
                var query = "select * from tipoPgto";
                return connection.Query<TipoPgto>(query).ToList();
            }
        }
    }
}
