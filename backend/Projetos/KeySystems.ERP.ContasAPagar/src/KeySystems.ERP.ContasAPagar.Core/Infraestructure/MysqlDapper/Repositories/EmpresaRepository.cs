using Dapper;
using KeySystems.ERP.ContasAPagar.Core.DomainModel.Empresa;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace KeySystems.ERP.ContasAPagar.Core.Infraestructure.MysqlDapper.Repositories
{
    public class EmpresaRepository
        : RepositoryBase
    {
        public EmpresaRepository(IConfiguration configuration) 
            : base(configuration) {}

        public IEnumerable<Empresa> Get()
        {
            using (var connection = base.MySqlConnection()) {

                var query = "select * from empresa";
                var result = connection.Query<Empresa>(query);

                return result;
            }
        }

        public Empresa Get(int id)
        {
            using (var connection = base.MySqlConnection())
            {
                var query = "select * from empresa where id = @id";
                var result = connection.QueryFirstOrDefault<Empresa>(
                        query, 
                        new { id = id}
                    );

                return result;
            }
        }

        public void Insert(Empresa empresa)
        {
            using (var connection =  base.MySqlConnection())
            {
                var query = "insert into empresa(razaoSocial, nomeBusca) " +
                    "values(@razaoSocial, @nomeBusca)";

                var result = connection.Execute(query,
                        new
                        {
                            razaoSocial = empresa.RazaoSocial,
                            nomeBusca = empresa.NomeBusca
                        });
            }
        }
    }
}
