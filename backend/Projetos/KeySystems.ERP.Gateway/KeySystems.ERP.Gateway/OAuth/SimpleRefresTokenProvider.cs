using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Threading.Tasks;

namespace KeySystems.ERP.Gateway.OAuth
{
    public class SimpleRefresTokenProvider
        : IAuthenticationTokenProvider
    {
        public Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            return Task.Run(() =>
            {
                var ticket = context.SerializeTicket();
                context.SetToken(ticket);

                //Guardar no banco de dados
            });
        }

        public Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            return Task.Run(() =>
            {
                //verificar se existe no banco de dados
                var refreshToken = context.Token;
                context.DeserializeTicket(refreshToken);
            });
        } 

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            throw new NotImplementedException();
        }

        public void Create(AuthenticationTokenCreateContext context)
        {
            throw new NotImplementedException();
        }
    }
}