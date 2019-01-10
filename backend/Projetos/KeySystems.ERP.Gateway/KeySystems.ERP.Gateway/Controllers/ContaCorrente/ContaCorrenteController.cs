using System.Web.Http;

namespace KeySystems.ERP.Gateway.Controllers
{
    //{}=>parametro que vem do cliente => http://dominio/api/erp/contacorrente/tenant/1231344
    [RoutePrefix("api/erp/contacorrente/tenant/{tenantid}")]
    public class ContaCorrenteController 
        : ApiController
    {

    }
}
