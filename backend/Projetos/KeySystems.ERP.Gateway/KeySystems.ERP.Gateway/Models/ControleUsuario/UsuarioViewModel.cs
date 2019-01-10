using System;

namespace KeySystems.ERP.Gateway.Models.ControleUsuario
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Nome { get; set; }
        public int IdTenant { get; set; }
        public string Sobrenome { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade {
            get {
                return DateTime.Now.Year - DataNascimento.Year;
            }
        }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; } = true;
    }
}