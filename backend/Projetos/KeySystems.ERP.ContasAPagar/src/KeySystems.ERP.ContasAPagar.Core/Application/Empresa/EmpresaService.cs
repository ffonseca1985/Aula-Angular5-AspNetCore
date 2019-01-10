using KeySystems.ERP.ContasAPagar.Core.Infraestructure.MysqlDapper.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace KeySystems.ERP.ContasAPagar.Core.Application.Empresa
{
    using DomainModel.Empresa;

    public class EmpresaService
    {
        private readonly EmpresaRepository _empresaRepository;

        public EmpresaService(EmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public IEnumerable<Empresa> Get()
        {
            return _empresaRepository.Get();
        }
    }
}
