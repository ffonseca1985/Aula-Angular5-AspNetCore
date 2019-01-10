using System;

namespace KeySystems.ERP.ContasAPagar.Core.DomainModel.ContasAPagar
{
    public class DadosPgto
    {
        public DadosPgto(DateTime dataPgto, decimal juros, decimal desconto,
            decimal valorParcela,
            decimal valorPago, int tipoPgtoId)
        {
            this.DataPgto = dataPgto;
            this.Juros = juros;
            this.Desconto = desconto;
            this.ValorPago = valorPago;
            this.TipoPgtoId = tipoPgtoId;

            this.ValidarPgto(valorParcela);
        }

        public DateTime DataPgto { get; private set; }
        public decimal Juros { get; private set; }
        public decimal Desconto { get; private set; }

        public int TipoPgtoId { get; private set; }

        public decimal ValorPago { get; private set; }

        public bool ValidarPgto(decimal valorParcela)
        {
            if ((valorParcela + this.Juros - this.Desconto) != this.ValorPago)
                return false;

            return true;
        }
    }
}
