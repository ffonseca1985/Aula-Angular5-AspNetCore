using Dapper;
using System.Data.SqlClient;

namespace KeySystems.ERP.ContaCorrente.Core.Infrastructure.MysqlDataBase.Repositories
{
    using DomainModel.ContaCorrente;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ContaCorrenteRepository
    {
        public void Add(ContaCorrente contaCorrente)
        {
            using (var connection = new SqlConnection("ConnectionString"))
            {
                var query = @"insert into ContaCorrente (
                                        Id, CodigoGrupo, CodigoSubGrupo, 
                                        Numero, CodigoEmpresa, DataCadastro)
                             values(@Id, 
                                        @CodigoGrupo, @CodigoSubGrupo,
                                        @Numero, @CodigoEmpresa, @DataCadastro)";
                connection.Execute(query,
                    new
                    {
                        Id = contaCorrente.Id,
                        CodigoGrupo = contaCorrente.Grupo,
                        SubGrupo = contaCorrente.SubGrupo,
                        Numero = contaCorrente.Conta,
                        CodigoEmpresa = contaCorrente.CodigoEmpresa,
                        DataCadastro = contaCorrente.DataCadastro
                    });
            }
        }

        public ContaCorrente GetById(Guid id)
        {
            return null;
        }

        public ContaCorrente
            Get(int grupo, int subGrupo, int numero, int codigoEmpresa)
        {
            using (var connection = new SqlConnection("ConnectionString"))
            {
                var contaCorrenteQuery = @"select Id, CodigoGrupo as Grupo, 
                               CodigoSubGrupo as SubGrupo, 
	                           Numero as Numero, 
	                           CodigoEmpresa from ContaCorrente
                           where CodigoGrupo = @CodigoGrupo
                                and CodigoSubGrupo = @CodigoSubGrupo
                                and Numero = @Numero
                                and CodigoEmpresa = @CodigoEmpresa";

                ContaCorrente cc = connection.Query<ContaCorrente>(contaCorrenteQuery,
                    new
                    {
                        CodigoGrupo = grupo,
                        CodigoSubGrupo = subGrupo,
                        Numero = numero,
                        CodigoEmpresa = codigoEmpresa
                    }).FirstOrDefault();


                var lancamentosQuery = @"select lc.id, cc.Id as IdContaCorrente, lc.Valor, 
                                            lc.Historico, tpl.Id as TipoLancamento from ContaCorrente cc
                                            join Lancamento lc on cc.Id = lc.IdContaCorrente
                                            join TipoLancamento tpl on lc.IdTipoLancamento = tpl.Id
                                        where cc.Id = @id";


                List<Lancamento> lancamentos = connection.Query<Lancamento>(lancamentosQuery, new { id = cc.Id }).ToList();

                foreach (var lancamento in lancamentos) {
                    cc.AdicionarLancamento(lancamento.Id, lancamento.IdContaCorrente, lancamento.Valor, lancamento.Historico, lancamento.TipoLancamento);
                } 

                return cc;
            }
        }

        public void AddLancamento(Guid idContaCorrente, Lancamento lancamento)
        {

            using (var connection = new SqlConnection("ConnectionString"))
            {
                var query = @"insert into Lancamento (
                                    Id, IdContaCorrente, IdTipoLancamento, 
                                    Valor, DataConciliacao, Historico, DataLancamento)
	                          values(@Id, @IdContaCorrente, @IdTipoLancamento,
                                    @Valor, @DataConciliacao, @Historico, @DataLancamento)";


                connection.Execute(query, new
                {
                    Id = lancamento.Id,
                    IdContaCorrente = lancamento.IdContaCorrente,
                    Valor = lancamento.Valor,
                    DataConciliacao = lancamento.DataConciliacao,
                    Historico = lancamento.Historico,
                    DataLancamento = lancamento.Historico
                });
            }
        }
    }
}
