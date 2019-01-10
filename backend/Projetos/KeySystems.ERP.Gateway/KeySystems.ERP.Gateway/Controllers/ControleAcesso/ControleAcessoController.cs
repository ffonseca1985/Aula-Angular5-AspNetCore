using KeySystems.ERP.Core.Application;
using KeySystems.ERP.Core.DomainModel;
using KeySystems.ERP.Core.InfraEstruture.Helper;
using KeySystems.ERP.Gateway.Models.ControleUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;

namespace KeySystems.ERP.Gateway.Controllers
{
    //[Authorize]
    [RoutePrefix("api/public/keysystems/erp/ControleDeAcesso/{idTenant}")]
    public class ControleAcessoController : ApiController
    {
        private readonly ApiApplicationService _applicationService;
        private readonly HttpHelper _httpHelper;
        private ModulosApi _moduloCorrente = ModulosApi.ControleDeAcesso;

        public ControleAcessoController(
            ApiApplicationService applicationService,
            HttpHelper httpHelper)
        {
            _applicationService = applicationService;
            _httpHelper = httpHelper;
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(int idTenant, [FromBody] CriarUsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Modelo invalido");

            Api api = _applicationService.Get(idTenant, _moduloCorrente.ToString(), (int)EMetodo.POST);

            if (api == null)
                return BadRequest("Api não mapeada para este método");

            var json = JsonConvert.SerializeObject(usuarioViewModel);

            var usuario = _httpHelper.Post<UsuarioViewModel>(api.Endpoint, json);
            var link = Url.Link("GetById", new { id = usuario.Id });
            
            return Created(link, usuario);
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Post(int idTenant, LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Login não informado");

            Api api = _applicationService.Get(idTenant, _moduloCorrente.ToString(), (int)EMetodo.POST);

            var json = JsonConvert.SerializeObject(loginViewModel);
            var usuario = _httpHelper.Post<UsuarioViewModel>(api.Endpoint, json);

            if (usuario == null)
                return NotFound();
            else
                return Ok();
        }

        [Route("usuario/{idUSuario}", Name = "GetById")]
        [HttpGet]
        public IHttpActionResult Get(int idTenant, int idUSuario)
        {
            if(idUSuario == default(int))
                return BadRequest();

            Api api = _applicationService.Get(idTenant, _moduloCorrente.ToString(), (int)EMetodo.POST);
            var usuario = _httpHelper.Get<UsuarioViewModel>(api.Endpoint, idUSuario);

            if (usuario == null)
                return  NotFound();

            return Ok(usuario);
        }

        [Route("", Name = "GetAll")]
        [HttpGet()]
        public IHttpActionResult Get(int idTenant)
        {
            try
            {
                if (idTenant == default(int))
                    return BadRequest("Cliente não informado");
                                
                Api api = _applicationService.Get(idTenant, _moduloCorrente.ToString(), (int)EMetodo.GET);

                //enviar os dados para a api correspondente
                var usuarios = _httpHelper.Get<List<UsuarioViewModel>>(api.Endpoint);

                //retornar para o frontend
                if (usuarios.Any())
                    return Ok(usuarios);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);   
            }
        }
    }
}
