using System;

namespace KeySystems.ERP.ContaCorrente.Core.DomainModel.ContaCorrente
{
    public class Lancamento : IEntity<Guid>
    {
        public Lancamento(
            Guid id,
            Guid idContaCorrente, 
            decimal valor, 
            string historico, 
            TipoLancamento tipoLancamento) : base(id)
        {
            AssertionConcern.AssertArgumentNotNull(id, 
                "Identtificador Lançamento não informado");

            AssertionConcern.AssertArgumentNotNull(idContaCorrente,
                "Conta Corrente não informada");

            AssertionConcern.AssertArgumentNotNull(valor,
                "O valor deve ser informado");

            AssertionConcern.AssertArgumentNotEmpty(historico,
                "O Histórico deve ser informado");
            
            this.DataLancamento = DateTime.Now;
            this.IdContaCorrente = idContaCorrente;
            this.Valor = valor;
            this.Historico = historico;
            this.TipoLancamento = tipoLancamento;
        }
        
        public DateTime DataLancamento { get; private set; }
        public DateTime DataConciliacao { get; private set; }

        public decimal Valor { get; private set; }
        public string Historico { get; private set; }

        public Guid IdContaCorrente { get; private set; }
        public TipoLancamento TipoLancamento { get; private set; }

        public void AdicionarDataConciliacao(DateTime dataConsciliacao)
        {
            AssertionConcern.AssertArgumentNotEquals(dataConsciliacao, 
                default(DateTime), "A Data deve ser informada");

            AssertionConcern.AssertArgumentFalse(dataConsciliacao >= DateTime.Now, 
                "Data consciliaçã inválida");

            this.DataConciliacao = dataConsciliacao;
        }    
    }
}
