namespace KeySystems.ERP.ContasAPagar.Core.DomainModel.Empresa
{
    public class Empresa : IEntity<int>
    {
        private Empresa() { }

        public Empresa(string razaoSocial, string nomeBusca)
        {
            this.RazaoSocial = razaoSocial;
            this.NomeBusca = nomeBusca;
        }
        public int Id { get; set; }
        public string RazaoSocial { get; private set; }
        public string NomeBusca { get; private set; }
    }
}
