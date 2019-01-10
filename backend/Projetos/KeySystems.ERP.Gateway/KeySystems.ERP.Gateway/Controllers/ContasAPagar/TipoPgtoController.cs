using KeySystems.ERP.Core.Application;
using KeySystems.ERP.Core.DomainModel;
using KeySystems.ERP.Core.InfraEstruture.Helper;
using KeySystems.ERP.Gateway.Models.ContasAPagar;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace KeySystems.ERP.Gateway.Controllers.ContasAPagar
{
    [RoutePrefix("api/public/keysystems/erp/{idTenant}/contasapagar/tipoPgto")]
    public class TipoPgtoController
        : ApiController
    {
        private readonly ApiApplicationService _applicationService;
        private readonly HttpHelper _httpHelper;
        private ModulosApi _moduloCorrente = ModulosApi.ContasAPagar;

        public TipoPgtoController(
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

            var tipoPgto = _httpHelper
                    .Get<List<TipoPgtoModel>>($"{api.Endpoint}/tipoPgto");

            if (tipoPgto == null || !tipoPgto.Any())
                return NotFound();

            return Ok(tipoPgto);
        }
    }
}
