using System;
using System.Runtime.InteropServices;

namespace KeySystems.ERP.ContaCorrente.Core.DomainModel.Empresa
{
    public class IdentificadorEmpresa
    {
        public IdentificadorEmpresa(Guid id, [Optional] int codigo)
        {
            //validação para casa

            this.Id = id;
            this.Codigo = codigo;
        }

        public Guid Id { get; private set; }
        public int Codigo { get; private set; }
    }
}
