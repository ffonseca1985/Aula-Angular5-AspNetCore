using KeySystems.ERP.ContasAPagar.Core.Infraestructure.MysqlDapper.Repositories;
using System.Collections.Generic;

namespace KeySystems.ERP.ContasAPagar.Core.Application.Fornecedor
{
    using DomainModel.Fornecedor;

    public class FornecedorService
    {
        private readonly FornecedorRepository _fornecedorRepository;

        public FornecedorService(FornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public IEnumerable<Fornecedor> Get()
        {
            return _fornecedorRepository.Get();
        }
    }
}
