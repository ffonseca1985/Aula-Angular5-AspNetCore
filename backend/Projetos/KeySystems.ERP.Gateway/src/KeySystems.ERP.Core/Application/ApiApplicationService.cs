using KeySystems.ERP.Core.DomainModel;
using KeySystems.ERP.Core.InfraEstruture.Mysql.Repositories;

namespace KeySystems.ERP.Core.Application
{
    public class ApiApplicationService
    {
        private readonly ApiRepository _apiRepository;
        private readonly ModuloRepository _moduloRepository;

        public ApiApplicationService(ApiRepository apiRepository,
            ModuloRepository moduloRepository)
        {
            _apiRepository = apiRepository;
            _moduloRepository = moduloRepository;
        }

        public Api Get(int idTenant, string nomeModulo, int idMetodo)
        {
            //Validações etc.
            var modulo = _moduloRepository.GetByName(nomeModulo);
            return _apiRepository.Get(idTenant, modulo.Id, idMetodo);
        }
    }
}
