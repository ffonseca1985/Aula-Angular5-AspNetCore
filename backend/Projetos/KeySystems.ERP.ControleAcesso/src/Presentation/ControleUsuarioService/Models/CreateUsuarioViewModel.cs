namespace KeySystems.ERP.ControleAcesso.ControleUsuarioService.Models
{
    public class CreateUsuarioViewModel
    {
        public int Id { get; private set; }
        public string UserName { get; set; }
        public System.DateTime DataNascimento { get; set; }
        public string Password { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public int IdTenant { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; } = true;
    }
}