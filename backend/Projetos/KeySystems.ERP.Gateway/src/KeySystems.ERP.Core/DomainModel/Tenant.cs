using System;

namespace KeySystems.ERP.Core.DomainModel
{
    public class Tenant
    {
        public Tenant(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
