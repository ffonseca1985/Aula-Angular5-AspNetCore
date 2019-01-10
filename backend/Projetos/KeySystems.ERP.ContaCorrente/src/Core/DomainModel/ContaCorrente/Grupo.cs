using KeySystems.ERP.ContaCorrente.Core.DomainModel.ContaCorrente.Identificadores;
using System;

namespace KeySystems.ERP.ContaCorrente.Core.DomainModel.ContaCorrente
{
    public class Grupo : IEntity<Guid, int>
    {
        public Grupo(IdentificadorGrupo identificadorGrupo, string nome)
            : base(identificadorGrupo.Id, 
                  identificadorGrupo.Codigo)
        {
            this.Nome = nome;
        }
        
        public string Nome { get; private set; }
    }
}
