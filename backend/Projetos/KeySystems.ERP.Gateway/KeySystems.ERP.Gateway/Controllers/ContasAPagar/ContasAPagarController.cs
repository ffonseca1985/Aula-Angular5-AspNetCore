using KeySystems.ERP.Gateway.Filters.ContasAPagar;
using System;
using System.Web.Http;

namespace KeySystems.ERP.Gateway.Controllers
{

    [RoutePrefix("api/public/keysystems/erp/{idTenant}/contasapagar")]
    public class ContasAPagarController : ApiController
    {
        [SelecionarContasAPagarFilter] //Filtro customizado
        [Route("")]
        public IHttpActionResult Get(Guid idTenant) {
            return Ok();
        }
        
    }
}
