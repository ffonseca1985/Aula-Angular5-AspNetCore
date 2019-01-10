using Dapper;
using KeySystems.ERP.Core.DomainModel;
using KeySystems.ERP.Core.InfraEstruture.Constants;
using MySql.Data.MySqlClient;

namespace KeySystems.ERP.Core.InfraEstruture.Mysql.Repositories
{
    public class ModuloRepository
    {
        public Modulo GetByName(string nome)
        {
            using (var connection = new MySqlConnection(QueryStringConstant.ConnectionErpKeySystems))
            {
                var query = "select * from modulo where Replace(Lower(Trim(nome)), ' ', '') = @nome";

                Modulo Modulo = connection.QueryFirstOrDefault<Modulo>(query, new {
                    nome =  nome
                    .ToLower().Trim()
                });

                return Modulo;
            }
        }
    }
}
