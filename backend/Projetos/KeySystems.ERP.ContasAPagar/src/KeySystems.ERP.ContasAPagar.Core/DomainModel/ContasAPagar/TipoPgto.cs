namespace KeySystems.ERP.ContasAPagar.Core.DomainModel.ContasAPagar
{
    public class TipoPgto : IEntity<int>
    {
        private TipoPgto(){}
        public TipoPgto(string descricao)
        {
            this.Descricao = descricao;
        }

        public int Id { get; private set; }
        public string Descricao { get; private set; }
    }
}
