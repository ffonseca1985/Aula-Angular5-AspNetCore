using System;

namespace KeySystems.ERP.ContaCorrente.Core.DomainModel.Empresa
{
    public class Empresa : IEntity<Guid, int>
    {
        public Empresa(IdentificadorEmpresa identificadorEmpresa, 
                       string razaoSocial, 
                       string nomeBusca) : base(identificadorEmpresa.Id)
        {
            AssertionConcern.AssertArgumentNotNull(identificadorEmpresa, "Identificador não informado");
            AssertionConcern.AssertArgumentNotEmpty(razaoSocial, "Razão social não informada");
            AssertionConcern.AssertArgumentNotEmpty(nomeBusca, "Nome busca não informada");

            this.Id = identificadorEmpresa.Id;
            this.Codigo = identificadorEmpresa.Codigo;
            this.RazaoSocial = razaoSocial;
            this.NomeBusca = nomeBusca;

        }

        public string RazaoSocial { get; private set; }
        public string NomeBusca { get; private set; }
    }
}
