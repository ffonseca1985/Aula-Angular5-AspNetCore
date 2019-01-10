using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using KeySystems.ERP.ControleAcesso.Core.Infraestructure.Security;

[assembly: OwinStartup(typeof(KeySystems.ERP.ControleAcesso.ControleUsuarioService.Startup))]

namespace KeySystems.ERP.ControleAcesso.ControleUsuarioService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            this.ConfigureRoute(config);
            this.ConfigureIdentity(app);
            this.ConfigureFormater(config);

            app.UseWebApi(config);
        }

        public void ConfigureIdentity(IAppBuilder app)
        {
            app.CreatePerOwinContext<CustomUserManager>(() =>
            {
                return new CustomUserManager();
            });

            app.CreatePerOwinContext<CustomRoleManager>(() =>
            {
                return new CustomRoleManager();
            });
        }

        public void ConfigureRoute(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
        }

        public void ConfigureFormater(HttpConfiguration config)
        {
            var settings = config.Formatters.JsonFormatter.SerializerSettings;

            //caso queira que meus clientes recebam apenas xml
            //config.Formatters.Remove(config.Formatters.XmlFormatter);

            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
