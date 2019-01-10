using KeySystems.ERP.Core.DomainModel;
using KeySystems.ERP.Core.InfraEstruture.Helper;
using KeySystems.ERP.Gateway.Models.ControleUsuario;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Reflection;

namespace KeySystems.ERP.Gateway.OAuth
{
    public class CustomOAuthAuthorizationServerProvider
        : OAuthAuthorizationServerProvider
    {
        private readonly HttpHelper _helper;

        public CustomOAuthAuthorizationServerProvider()
        {
            _helper = new HttpHelper();
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.CompletedTask;
        }

        
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            await Task.Run(() => {

                var userName = context.UserName;
                var password = context.Password;

                string urlCurrent = "http://localhost:3086/api/private/keysystems/erp/ControleDeAcesso/usuario/login";

                LoginViewModel loginModel = new LoginViewModel()
                {
                    Password = password,
                    UserName = userName
                };

                var json = JsonConvert.SerializeObject(loginModel);
                UsuarioViewModel user = _helper.Post<UsuarioViewModel>(urlCurrent, json);

                if (user == null)
                {
                    context.SetError("invalid_login", "Credenciais inválidas");
                    return;
                }
                else
                {
                    //definindos minhas declarações => profile
                    var claims = new List<Claim>();
                    var properties = user.GetType().GetTypeInfo().GetProperties();

                    foreach (var item in properties)
                    {
                        var objValue = item.GetValue(user);
                        string value = objValue == null ? string.Empty : objValue.ToString();

                        claims.Add(new Claim(item.Name, value));
                    }

                    var identificacao = new ClaimsIdentity(claims, 
                        context.Options.AuthenticationType);

                    var token = new AuthenticationTicket(identificacao, null);
                    context.Validated(token);
                }
            });
        }

        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            return Task.Run(() =>
            {
                var newTicket = new AuthenticationTicket(context.Ticket.Identity, context.Ticket.Properties);
                context.Validated(newTicket);
            });
        }
    }
}