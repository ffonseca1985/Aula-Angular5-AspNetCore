using Dapper;
using KeySystems.ERP.ContaCorrente.Core.DomainModel.Empresa;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace KeySystems.ERP.ContaCorrente.Core.Infrastructure.MysqlDataBase.Repositories
{
    public class EmpresaRepository
    {
        public void Add(Empresa empresa)
        {
            using (var connection = new SqlConnection("string conexao"))
            {
                var query = "insert into empresa(id, razaoSocial, nomeBusca) " +
                    "values(@id, @razaoSocial, @nomeBusca)";

                int linhasAfetadas = connection.Execute(query,
                                new {
                                        id = empresa.Id.ToString(),
                                        razaoSocial = empresa.RazaoSocial,
                                        nomeBusca = empresa.NomeBusca
                                });

                System.Console.WriteLine($"Total Linhas Afetadas {linhasAfetadas}");
            }
        }

        public Empresa Get(Guid id)
        {
            using (var connection = new SqlConnection("string conexao"))
            {
                var query = "select id, codigo, razaoSocial, nomeBusca from Empresa " +
                    "where id = @id";

                var empresa = connection.Query<Empresa>(query, new { id = id })
                    .FirstOrDefault();

                return empresa;
            }
        }
    }
}
