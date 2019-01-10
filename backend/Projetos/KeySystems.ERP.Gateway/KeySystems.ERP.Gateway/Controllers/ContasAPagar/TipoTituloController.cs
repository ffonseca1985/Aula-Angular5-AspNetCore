using KeySystems.ERP.Core.Application;
using KeySystems.ERP.Core.DomainModel;
using KeySystems.ERP.Core.InfraEstruture.Helper;
using KeySystems.ERP.Gateway.Models.ContasAPagar;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace KeySystems.ERP.Gateway.Controllers.ContasAPagar
{
    [RoutePrefix("api/public/keysystems/erp/{idTenant}/contasapagar/tipotitulo")]
    public class TipoTituloController : ApiController
    {
        private readonly ApiApplicationService _applicationService;
        private readonly HttpHelper _httpHelper;
        private ModulosApi _moduloCorrente = ModulosApi.ContasAPagar;

        public TipoTituloController(
           ApiApplicationService applicationService,
           HttpHelper httpHelper)
        {
            _applicationService = applicationService;
            _httpHelper = httpHelper;
        }

        [Route("")]
        public IHttpActionResult Get(int idTenant)
        {
            if (idTenant == default(int))
                return BadRequest("Cliente não informado");

            Api api = _applicationService.Get(idTenant,
                _moduloCorrente.ToString(), (int)EMetodo.GET);

            var tipoTitulo = _httpHelper
                    .Get<List<TipoTituloModel>>($"{api.Endpoint}/tipotitulo");

            if (tipoTitulo == null || !tipoTitulo.Any())
                return NotFound();

            return Ok(tipoTitulo);
        }
    }
}
