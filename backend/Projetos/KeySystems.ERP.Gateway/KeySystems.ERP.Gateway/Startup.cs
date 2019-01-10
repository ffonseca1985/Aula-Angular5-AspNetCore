using KeySystems.ERP.Gateway.OAuth;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Owin;
using SimpleInjector;

using System;
using System.Web.Http;
using KeySystems.ERP.Core.InfraEstruture.ServiceLocator;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

[assembly: OwinStartup(typeof(KeySystems.ERP.Gateway.Startup))]

namespace KeySystems.ERP.Gateway
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //usado para utilizar junto com o webapi
            //Install-Package microsoft.aspnet.webapi.owin

            //usado para fazer a aparte da segurança
            //Install-Package microsoft.owin.security
            //Install-Package microsoft.owin.security.oauth

            //Funcionar junto com o servidor IIS
            //Install-Package microsoft.Owin.Host.SystemWeb

            //Pacotes para se trabalhar com JWT
            //Microsoft.IdentityModel.Tokens
            //System.IdentityModel.Tokens.Jwt
            //Thinktecture.IdentityModel.Core

            //Gerenciar o Cors
            //Install - Package microsoft.owin.cors

            //Vamos definir uma variavel de configuração
            var config = new HttpConfiguration();           

            //Todo mundo deve ser proibido de entrar nesta aplicação
            //se não estiver autenticado/Autenticado
            //config.Filters.Add(new AuthorizeAttribute());

            //Configurando uma rota
            this.ConfigureRoute(config);

            //configurando formatos
            this.ConfigureFormater(config);

            //habilitando requests de diferentes lugares!!!
            app.UseCors(CorsOptions.AllowAll);

            //Middleware para gerenciar a authenticação/Autorização
            this.UseOAuth(app);

            this.ConfigureServiceLocator(config);

            //após a configuração de tudo
            app.UseWebApi(config);
        }

        public void ConfigureServiceLocator(HttpConfiguration configuration)
        {
            var container = new Container();
            container.Options.DefaultLifestyle = new AsyncScopedLifestyle();

            container.Initialize(new AsyncScopedLifestyle());

            container.RegisterWebApiControllers(configuration);

            container.Verify();

            configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }

        public void UseOAuth(IAppBuilder app)
        {
            var optionsAuthentication = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true, //garantir que http e https funcione
                TokenEndpointPath = new PathString("/api/public/keysystems/erp/token"), //Caminho virtual
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
                Provider = new CustomOAuthAuthorizationServerProvider(), //faz o processo de geração do token
                RefreshTokenProvider = new SimpleRefresTokenProvider(),
                AccessTokenFormat = new CustomJWTFormat()
            };

            app.UseOAuthAuthorizationServer(optionsAuthentication);

            //app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            byte[] keyByte = TextEncodings.Base64Url.Decode(Constants.key);

            var optionsJwtAutentication = new JwtBearerAuthenticationOptions()
            {
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
                AllowedAudiences = new[] { Constants.aud },
                IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                {
                    new SymmetricKeyIssuerSecurityTokenProvider(Constants.issuer, keyByte)
                }
            };

            app.UseJwtBearerAuthentication(optionsJwtAutentication);
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
