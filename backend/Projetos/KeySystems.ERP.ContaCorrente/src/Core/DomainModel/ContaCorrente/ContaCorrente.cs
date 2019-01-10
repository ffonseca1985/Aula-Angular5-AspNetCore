using KeySystems.ERP.ContaCorrente.Core.DomainModel.ContaCorrente.Identificadores;
using KeySystems.ERP.ContaCorrente.Core.DomainModel.Empresa;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace KeySystems.ERP.ContaCorrente.Core.DomainModel.ContaCorrente
{
    public class ContaCorrente : IEntity<Guid, int, int, int>
    {
        public ContaCorrente (
            IdentificadorContaCorrente identificadorContaCorrente,
            int codigoEmpresa,
            DateTime dataCadastro) 
                : base(identificadorContaCorrente.Id, 
                       identificadorContaCorrente.Grupo, 
                       identificadorContaCorrente.SubGrupo, 
                       identificadorContaCorrente.Numero)
        {
            this.Grupo = identificadorContaCorrente.Grupo;
            this.SubGrupo = identificadorContaCorrente.SubGrupo;
            this.Conta = identificadorContaCorrente.Numero;
            this.CodigoEmpresa = codigoEmpresa;
            this.DataCadastro = dataCadastro;
        }

        public int CodigoEmpresa { get; private set; }
        public List<Lancamento> Lancamentos { get; private set; } = new List<Lancamento>();

        public void AdicionarLancamento(
            Guid idLancamento,
            Guid idContaCorrente,
            decimal valor,
            string historico,
            TipoLancamento tipoLancamento)
        {
            this.Lancamentos.Add(new Lancamento(idLancamento, idContaCorrente, 
                valor, historico, tipoLancamento));
        }

        public static bool IdentificadorValido(string identificador)
        {
            var pattern = "^[0-9]{3}-[0-9]{3}-[0-9]{3}$";

            return Regex.IsMatch(identificador, pattern);
        }

        public decimal Saldo()
        {
            decimal total = 0;

            foreach (var lancamento in this.Lancamentos)
            {
                if (lancamento.TipoLancamento == TipoLancamento.Credito)
                {
                    total += lancamento.Valor;
                    continue;
                }

                if (lancamento.TipoLancamento == TipoLancamento.Debito)
                {
                    total -= lancamento.Valor;
                    continue;
                }
            }
            return total;
        }

        public DateTime DataCadastro { get; private set; }
    }
}
