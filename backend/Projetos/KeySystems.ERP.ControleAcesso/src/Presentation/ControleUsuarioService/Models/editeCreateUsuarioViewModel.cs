namespace KeySystems.ERP.ControleAcesso.ControleUsuarioService.Models
{
    public class EditeCreateUsuarioViewModel
    {
        public int Id { get; private set; }
        public string UserName { get; set; }
        public string Password { get; private set; }
        public string NomeCompleto { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; } = true;
    }
}