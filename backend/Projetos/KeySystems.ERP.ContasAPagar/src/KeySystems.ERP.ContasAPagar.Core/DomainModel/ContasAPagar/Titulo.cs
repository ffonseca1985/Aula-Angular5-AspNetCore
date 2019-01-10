using System;
using System.Collections.Generic;

namespace KeySystems.ERP.ContasAPagar.Core.DomainModel.ContasAPagar
{
    public class Titulo : IEntity<int>
    {
        public Titulo(int idEmpresa, int idTipoTitulo, int idFornecedor)
        {
            if (idEmpresa == default(int))
                throw new ArgumentException("Titulo", "Empresa não informada");

            if (idTipoTitulo == default(int))
                throw new ArgumentException("Titulo", "Tipo Titulo não informado");

            if (idFornecedor == default(int))
                throw new ArgumentException("Titulo", "Fornecedor não informado");

            this.IdEmpresa = idEmpresa;
            this.IdTipoTitulo = idTipoTitulo;
            this.IdFornecedor = idFornecedor;
        }

        public int Id { get; private set; }
        public int IdEmpresa { get; private set; }
        public int IdTipoTitulo { get; private set; }
        public int IdFornecedor { get; private set; }
        public decimal Total { get; set; }

        public List<Parcela> Parcelas { get; private set; } = new List<Parcela>();

        

    }
}
