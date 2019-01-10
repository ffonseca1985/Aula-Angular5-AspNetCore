using KeySystems.ERP.ContaCorrente.Core.DomainModel.ContaCorrente.Identificadores;
using System;

namespace KeySystems.ERP.ContaCorrente.Core.DomainModel.ContaCorrente
{
    public class SubGrupo : IEntity<Guid, int>
    {
        public SubGrupo(
            IdentificadorSubGrupo identificadorSubGrupo, 
            Guid idGrupo,
            string nome) : base(identificadorSubGrupo.Id, identificadorSubGrupo.Codigo)
        {
            //As valição serão para casa!!!
            this.Nome = nome;
        }
        
        public string Nome { get; private set; }
    }
}
