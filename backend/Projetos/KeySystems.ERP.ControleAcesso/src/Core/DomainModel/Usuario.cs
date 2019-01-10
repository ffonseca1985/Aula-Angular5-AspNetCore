using KeySystems.ERP.ControleAcesso.Core.Infraestructure.Security;
using Microsoft.AspNet.Identity;
using System;

namespace KeySystems.ERP.ControleAcesso.Core.DomainModel
{
    public class Usuario
        : IUser<int>
    {
        private Usuario() { }

        public Usuario(string userName)
        {
            this.UserName = userName;
        }

        public int Id { get; private set; }
        public string UserName { get; set; }

        public string Hash { get; set; }
        public string NomeCompleto {
            get
            {
                return $"{this.Nome} {this.SobreNome}";
            }
        }
        public string Nome { get; set; }
        public string SobreNome { get; set; }

        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; } = true;
        public DateTime DataNascimento { get; set; }
        public int IdTenant { get; set; }
    }
}
