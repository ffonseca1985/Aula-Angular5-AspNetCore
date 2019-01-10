using System;

namespace KeySystems.ERP.ContaCorrente.Core.Application.ContaCorrente.Dtos
{
    public class ContaCorrenteRequest
    {
        public Guid IdContaCorrente { get; set; } = Guid.NewGuid();
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public int Grupo { get; set; }
        public int SubGrupo { get; set; }
        public int CoditoEmpresa { get; set; }
        public int Numero { get; set; }
    }
}
