namespace KeySystems.ERP.ContasAPagar.Core.DomainModel.Fornecedor
{
    public class Fornecedor : IEntity<int>
    {
        private Fornecedor() { }
        public Fornecedor(int id, string nomeBusca, string razaoSocial)
        {
            this.NomeBusca = nomeBusca;
            this.RazaoSocial = razaoSocial;
        }

        public int Id { get; set; }
        public string RazaoSocial { get; private set; }
        public string NomeBusca { get; private set; }
    }
}
