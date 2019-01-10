using System;
using System.Collections.Generic;
using System.Text;

namespace KeySystems.ERP.ContasAPagar.Core.Application.ContasAPagar.TipoPgto
{
    using DomainModel.ContasAPagar;
    using KeySystems.ERP.ContasAPagar.Core.Infraestructure.MysqlDapper.Repositories;

    public class TipoPgtoService
    {
        private readonly TipoPgtoRepository _tipoPgtoRepository;

        public TipoPgtoService(TipoPgtoRepository tipoPgtoRepository)
        {
            _tipoPgtoRepository = tipoPgtoRepository;
        }

        public List<TipoPgto> Get()
        {
            return _tipoPgtoRepository.Get();
        }
    }
}
