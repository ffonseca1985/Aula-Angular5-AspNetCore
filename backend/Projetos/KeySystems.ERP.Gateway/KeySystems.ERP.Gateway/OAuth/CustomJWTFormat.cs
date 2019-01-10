using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using System;
using System.IdentityModel.Tokens;
using System.Text;
using Thinktecture.IdentityModel.Tokens;

namespace KeySystems.ERP.Gateway.OAuth
{
    public class CustomJWTFormat
        : ISecureDataFormat<AuthenticationTicket>
    {
        public string Protect(AuthenticationTicket ticket)
        {
            if (ticket == null)
                throw new ArgumentException("Token não informado");

            byte[] keyByte = TextEncodings.Base64Url.Decode(Constants.key);
            var signKey = new HmacSigningCredentials(keyByte);

            var issuer = Constants.issuer;
            var audience = Constants.aud;
            var claims = ticket.Identity.Claims;

            var token = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    claims:claims,
                    notBefore: ticket.Properties.IssuedUtc.Value.UtcDateTime,
                    expires: ticket.Properties.ExpiresUtc.Value.UtcDateTime,
                    signingCredentials: signKey
                );
            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.WriteToken(token);
            return jwt;
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}