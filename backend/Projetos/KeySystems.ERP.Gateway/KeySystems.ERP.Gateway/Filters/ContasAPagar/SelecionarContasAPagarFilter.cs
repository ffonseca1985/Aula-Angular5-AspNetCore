using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace KeySystems.ERP.Gateway.Filters.ContasAPagar
{
    //Para customizar os nossos filtros basta herdar de AuthorizeAttribute
    //e sobrescrever  método OnAuthorization
    public class SelecionarContasAPagarFilter
        : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var user = HttpContext.Current.User as ClaimsPrincipal;

            var roles = user.Claims.Where(x => x.Type == ClaimTypes.Role);
            ;
            if (roles.Any(x => x.Value == "Administrador"))
                base.OnAuthorization(actionContext);
            else
                base.HandleUnauthorizedRequest(actionContext);
        }
    }
}