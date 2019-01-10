using System;

namespace KeySystems.ERP.Core.DomainModel
{
    public class Metodos
    {
        public Metodos(EMetodo metodo)
        {
            this.Nome = metodo.ToString();
            this.Id = Convert.ToInt32(metodo);
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
    }

    public enum EMetodo
    {    
        GET = 1,
        POST = 2,
        UPDATE = 3,
        DELETE = 4
    }
}
