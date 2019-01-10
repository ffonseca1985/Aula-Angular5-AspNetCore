using System;

namespace KeySystems.ERP.ContaCorrente.Core.Application.ContaCorrente.Dtos
{
    public class LancamentoRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int TipoLancamento { get; set; }
        public decimal Valor { get; set; }
        public string Historico { get; set; }
    }
}
