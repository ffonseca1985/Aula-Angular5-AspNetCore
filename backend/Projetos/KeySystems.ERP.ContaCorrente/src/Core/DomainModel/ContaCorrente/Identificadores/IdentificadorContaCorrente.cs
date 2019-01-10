using System;

namespace KeySystems.ERP.ContaCorrente.Core.DomainModel.ContaCorrente.Identificadores
{
    public class IdentificadorContaCorrente
    {
        public IdentificadorContaCorrente(
            Guid id,  
            int grupo, 
            int subGrupo, 
            int numero)
        {
            //Validações para o lar
            this.Id = id;
            this.Grupo = grupo;
            this.SubGrupo = subGrupo;
            this.Numero = numero;
        }

        public Guid Id { get; private set; }
        public int Grupo { get; private set; }
        public int SubGrupo { get; private set; }
        public int Numero { get; private set; }
    }
}
