using Microsoft.AspNet.Identity;

namespace KeySystems.ERP.ControleAcesso.Core.DomainModel
{
    public class Role
        : IRole<int>
    {
        public Role(string nome)
        {
            this.Name = nome;
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public bool Ativo { get; set; } = true;
    }
}
