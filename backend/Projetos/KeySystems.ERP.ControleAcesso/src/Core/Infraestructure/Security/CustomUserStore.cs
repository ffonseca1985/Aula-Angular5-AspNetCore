using KeySystems.ERP.ControleAcesso.Core.DomainModel;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

//classe Driver Mysql
using MySql.Data.MySqlClient;

//Helper para ajudar na connection
using Dapper;
using KeySystems.ERP.ControleAcesso.Core.Infraestructure.Constants;
using System.Collections.Generic;
using System.Linq;

namespace KeySystems.ERP.ControleAcesso.Core.Infraestructure.Security
{
    //Prepara todas as regras (melhores práticas)
    //para selecionar e alterar uma conta/ usuário
    public class CustomUserStore
        : IUserStore<Usuario, int>,
        IUserPasswordStore<Usuario, int>,
        IUserRoleStore<Usuario, int>
    {
        private CustomRoleStore CustomRoleStore;

        public CustomUserStore()
        {
            CustomRoleStore = new CustomRoleStore();
        }

        public async Task<IQueryable<Usuario>> Get()
        {
            using (var mysqlConnection = new MySqlConnection(QuerystringConstant.KeySystems))
            {
                var usuarios = await mysqlConnection.QueryAsync<Usuario>("select * from usuario");

                IQueryable<Usuario> result = usuarios.AsQueryable<Usuario>();

                return result;
            };
        }

        public async Task AddToRoleAsync(Usuario user, string roleName)
        {
            using (var mysqlConnection =
                   new MySqlConnection(QuerystringConstant.KeySystems))
            {
                var role = await CustomRoleStore.FindByNameAsync(roleName);
                var roleId = role.Id;

                var query = "insert into UsuarioRole values (@idUsuario, @idRole)";

                using (var command = new MySqlCommand(query, mysqlConnection))
                {
                    command.Parameters.AddWithValue("@idUsuario", user.Id);
                    command.Parameters.AddWithValue("@idRole", roleId);

                    await command.ExecuteNonQueryAsync();
                };
            }
        }

        public async Task CreateAsync(Usuario user)
        {
            using (var mysqlConnection =
                new MySqlConnection(QuerystringConstant.KeySystems))
            {
                var query =
                        "insert into Usuario(" +
                            "UserName, hash, Nome, " +
                            "cpf, email, telefone, sobrenome, idtenant, " +
                            "ativo, dataNascimento" +
                        ") " +
                        "values (" +
                            "@UserName, " +
                            "@hash," +
                            "@Nome," +
                            "@Cpf," +
                            "@Email," +
                            "@Telefone," +
                            "@SobreNome, " +
                            "@idtenant," +
                            "@ativo," +
                            "@dataNascimento)"; 

                await mysqlConnection.ExecuteAsync(query, 
                        new {
                            user.UserName,
                            hash = user.Hash,
                            user.Nome,
                            user.Cpf,
                            user.Email,
                            user.Telefone,
                            user.SobreNome,
                            user.IdTenant,
                            user.Ativo,
                            user.DataNascimento
                        });
            };
        }

        public Task DeleteAsync(Usuario user)
        {
            using (var mysqlConnection =
               new MySqlConnection(QuerystringConstant.KeySystems))
            {
                var query = "update usuario set Ativo = false where id = @id limit 1";
                return mysqlConnection.QueryAsync(query, new { id = user.Id });
            };
        }

        public void Dispose() { }

        public async Task<Usuario> FindByIdAsync(int userId)
        {
            using (var mysqlConnection =
               new MySqlConnection(QuerystringConstant.KeySystems))
            {
                var query = "select * from  usuario where id = @id ";
                return await mysqlConnection.QueryFirstOrDefaultAsync<Usuario>(query, new { id = userId });
            }
        }

        public async Task<Usuario> FindByNameAsync(string userName)
        {
            using (var mysqlConnection =
               new MySqlConnection(QuerystringConstant.KeySystems))
            {
                var query = "select * from  usuario where userName = @userName ";
                var usuario = await mysqlConnection.QueryFirstOrDefaultAsync<Usuario>(query, new { userName = userName });

                return usuario;
            }
        }

        public Task<string> GetPasswordHashAsync(Usuario user)
        {
            return Task.Run(() =>
            {
                return user.Hash;
            });
        }

        public Task<IList<string>> GetRolesAsync(Usuario user)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(Usuario user)
        {
            return Task.Run(() =>
            {
                return user.Hash != null;
            });
        }

        public async Task<bool> IsInRoleAsync(Usuario user, string roleName)
        {
            using (var mysqlConnection =
               new MySqlConnection(QuerystringConstant.KeySystems))
            {
                var role = await CustomRoleStore.FindByNameAsync(roleName);
                var roleId = role.Id;

                var query = "select 1 from UsuarioRole where idUsuario = @idUsuario " +
                    "and idRole = @idRole limit 1";

                return await mysqlConnection.QueryFirstOrDefaultAsync<bool>(query,
                    new { idUsuario = user.Id, idRole = roleId });
            };
        }

        public async Task RemoveFromRoleAsync(Usuario user, string roleName)
        {
            using (var mysqlConnection =
                  new MySqlConnection(QuerystringConstant.KeySystems))
            {
                var role = await CustomRoleStore.FindByNameAsync(roleName);
                var roleId = role.Id;

                var query = "delete from UsuarioRole where idUsuario = @idUsuario " +
                    "and idRole = @idRole limit 1";

                using (var command = new MySqlCommand(query, mysqlConnection))
                {
                    command.Parameters.AddWithValue("@idUsuario", user.Id);
                    command.Parameters.AddWithValue("@idRole", roleId);

                    await command.ExecuteNonQueryAsync();
                };
            };

        }

        public Task SetPasswordHashAsync(Usuario user, string passwordHash)
        {
            return Task.Run(() =>
            {
                user.Hash = passwordHash;
            });
        }

        public async Task UpdateAsync(Usuario user)
        {
            using (var mysqlConnection =
                new MySqlConnection(QuerystringConstant.KeySystems))
            {
                var query = "update Usuario set " +
                    " UserName = @UserName," +
                    " Password = @Password," +
                    " NomeCompleto=@NomeCompleto," +
                    " Cpf=@Cpf," +
                    " Email=@Email," +
                    " Telefone=Telefone" +
                    " where id = @id limit 1";

                using (var command = new MySqlCommand(query, mysqlConnection))
                {
                    command.Parameters.AddWithValue("@UserName", user.UserName);
                    command.Parameters.AddWithValue("@Password", user.Hash);
                    command.Parameters.AddWithValue("@NomeCompleto", user.NomeCompleto);
                    command.Parameters.AddWithValue("@Cpf", user.Cpf);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Telefone", user.Telefone);
                    command.Parameters.AddWithValue("@id", user.Id);

                    await command.ExecuteNonQueryAsync();
                };
            };
        }
    }
}
