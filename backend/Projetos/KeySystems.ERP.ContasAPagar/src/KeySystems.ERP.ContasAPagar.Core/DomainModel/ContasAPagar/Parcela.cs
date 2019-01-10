using System;

namespace KeySystems.ERP.ContasAPagar.Core.DomainModel.ContasAPagar
{
    public class Parcela : IEntity<int>
    {
        public Parcela(int id, DateTime dataVencimento, decimal valor)
        {
            this.Id = id;
            this.DataVencimento = dataVencimento;
            this.Valor = valor;
        }

        public int Id { get; private set; }
        //public int Ordem { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public decimal Valor { get; private set; }

        //Um objeto de Valor, ele não tem Id
        //Os Dados de Pagto ficarão na mesma tabela da Parcela
        public DateTime DataPgto { get; private set; }
        public decimal Juros { get; private set; }
        public decimal Desconto { get; private set; }

        public int TipoPgtoId { get; private set; }
        public TipoPgto TipoPgto { get; set; }

        public decimal ValorPago { get; private set; }

        public bool ValidarPgto(decimal valorParcela)
        {
            if ((valorParcela + this.Juros - this.Desconto) != this.ValorPago)
                return false;

            return true;
        }

        public void AdicionarPgto(DateTime dataPgto, decimal juros, decimal desconto, decimal valorPgto, int tipoPgtoId)
        {
            this.DataPgto = dataPgto;
            this.Juros = juros;
            this.Desconto = desconto;
            this.Valor = valorPgto;
            this.TipoPgtoId = tipoPgtoId;
        }
    }
}
