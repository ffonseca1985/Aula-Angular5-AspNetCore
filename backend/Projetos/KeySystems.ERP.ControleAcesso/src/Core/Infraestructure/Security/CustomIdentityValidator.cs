using KeySystems.ERP.ControleAcesso.Core.DomainModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeySystems.ERP.ControleAcesso.Core.Infraestructure.Security
{
    public class CustomIdentityValidator : IIdentityValidator<Usuario>
    {
        public Task<IdentityResult> ValidateAsync(Usuario item)
        {
            return null;
        }
    }
}
