using System;
using System.Collections.Generic;
using System.Text;

namespace KeySystems.ERP.ContasAPagar.Core.Application.ContasAPagar.TipoTitulo
{
    using DomainModel.ContasAPagar;
    using KeySystems.ERP.ContasAPagar.Core.Infraestructure.MysqlDapper.Repositories;

    public class TipoTituloService
    {
        private readonly TipoTituloRepository _tipoTituloRepository;

        public TipoTituloService(TipoTituloRepository tipoTituloRepository)
        {
            _tipoTituloRepository = tipoTituloRepository;
        }

        public List<TipoTitulo> Get()
        {
            return _tipoTituloRepository.Get();
        }
    }
}
