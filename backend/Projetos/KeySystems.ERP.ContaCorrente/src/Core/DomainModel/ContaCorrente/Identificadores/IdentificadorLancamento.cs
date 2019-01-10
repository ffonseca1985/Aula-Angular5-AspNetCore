using System;

namespace KeySystems.ERP.ContaCorrente.Core.DomainModel.ContaCorrente.Identificadores
{
    public class IdentificadorLancamento
    {
        public IdentificadorLancamento(Guid id, int codigo)
        {
            //validações para casa!!

            this.Id = id;
            this.Codigo = codigo;
        }

        public int Codigo { get; private set; }
        public Guid Id { get; private set; }
    }
}
