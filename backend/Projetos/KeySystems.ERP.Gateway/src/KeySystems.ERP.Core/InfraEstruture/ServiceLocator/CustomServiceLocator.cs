using KeySystems.ERP.Core.Application;
using KeySystems.ERP.Core.InfraEstruture.Helper;
using KeySystems.ERP.Core.InfraEstruture.Mysql.Repositories;
using SimpleInjector;

namespace KeySystems.ERP.Core.InfraEstruture.ServiceLocator
{
    public static class CustomServiceLocator
    {
        public static Container Initialize(this Container container, Lifestyle lifestile)
        {
            container.Register<ApiApplicationService>(lifestile);
            container.Register<HttpHelper>(lifestile);
            container.Register<ApiRepository>(lifestile);
            container.Register<ModuloRepository>();
            container.Register<ClientRepository>();

            return container;
        }
    }
}
