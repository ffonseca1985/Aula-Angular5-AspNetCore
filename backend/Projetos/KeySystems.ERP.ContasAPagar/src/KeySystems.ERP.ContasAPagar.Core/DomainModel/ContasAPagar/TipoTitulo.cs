namespace KeySystems.ERP.ContasAPagar.Core.DomainModel.ContasAPagar
{
    public class TipoTitulo : IEntity<int>
    {
        private TipoTitulo() { }
        public TipoTitulo(string descricao)
        {
            this.Descricao = descricao;
        }

        public int Id { get; private set; }
        public string Descricao { get; private set; }
    }
}
