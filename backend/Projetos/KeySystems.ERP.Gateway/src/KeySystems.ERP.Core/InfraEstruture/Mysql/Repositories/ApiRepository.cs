using KeySystems.ERP.Core.DomainModel;
using Dapper;
using KeySystems.ERP.Core.InfraEstruture.Constants;
using MySql.Data.MySqlClient;

namespace KeySystems.ERP.Core.InfraEstruture.Mysql.Repositories
{
    public class ApiRepository
    {
        public Api Get(int idTenant, int idModulo, int idMetodo)
        {
            using (var connection = new MySqlConnection
                            (QueryStringConstant.ConnectionErpKeySystems))
            {
                var query = "select * from Api where idTenant = @idTenant and" +
                    " idModulo = @idModulo and idMetodo = @idMetodo";

                Api api = connection.QueryFirstOrDefault<Api>(query, new
                {
                    idTenant = idTenant,
                    idModulo = idModulo,
                    idMetodo = idMetodo
                });

                return api;
            }
        }
    }
}
