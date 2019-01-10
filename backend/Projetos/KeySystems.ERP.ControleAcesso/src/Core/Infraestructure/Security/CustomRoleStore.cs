using Dapper;
using KeySystems.ERP.ControleAcesso.Core.DomainModel;
using KeySystems.ERP.ControleAcesso.Core.Infraestructure.Constants;
using Microsoft.AspNet.Identity;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace KeySystems.ERP.ControleAcesso.Core.Infraestructure.Security
{
    public class CustomRoleStore
        : IRoleStore<Role, int>
    {
        public Task CreateAsync(Role role)
        {
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Role role)
        {
            using (var mysqlConnection =
               new MySqlConnection(QuerystringConstant.KeySystems))
            {
                var query = "update role set ativo = false where name = @name limit 1";
                return mysqlConnection.QueryAsync(query, new { name = role.Name });
            };
        }

        public void Dispose()
        {
        }

        public Task<Role> FindByIdAsync(int roleId)
        {
            return Task.FromResult<Role>(null);
        }

        public async Task<Role> FindByNameAsync(string roleName)
        {
            using (var mysqlConnection =
                new MySqlConnection(QuerystringConstant.KeySystems))
            {
                var query = "select 1 from Role where name = @roleName";

                var role = await mysqlConnection.QueryFirstAsync(query, new { roleName = roleName });
                return role;
            };
        }

        public Task UpdateAsync(Role role)
        {
            return Task.CompletedTask;
        }
    }
}
