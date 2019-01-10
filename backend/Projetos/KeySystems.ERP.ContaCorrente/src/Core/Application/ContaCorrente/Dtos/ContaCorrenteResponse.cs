using System.Collections.Generic;

namespace KeySystems.ERP.ContaCorrente.Core.Application.ContaCorrente.Dtos
{
    public class ContaCorrenteResponse
    {
        public List<LancamentoRequest> Lancamentos { get; set; }
        public int Grupo { get; set; }
        public int SubGrupo { get; set; }
        public int Numero { get; set; }
        public int CodigoEmpresa { get; set; }
    }
}
