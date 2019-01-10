using System;

namespace KeySystems.ERP.Core.DomainModel
{
    public class Modulo
    {
        public Modulo(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        
    }

    public enum ModulosApi
    {
         ControleDeAcesso,
         ContasAPagar,
         ContasAReceber
    }
}
