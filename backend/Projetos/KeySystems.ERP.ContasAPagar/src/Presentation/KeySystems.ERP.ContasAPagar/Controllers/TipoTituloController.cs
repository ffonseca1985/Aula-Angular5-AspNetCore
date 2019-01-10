using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using KeySystems.ERP.ContasAPagar.Core.Application.ContasAPagar.TipoTitulo;
using KeySystems.ERP.ContasAPagar.Models;
using Microsoft.AspNetCore.Mvc;

namespace KeySystems.ERP.ContasAPagar.Controllers
{
    [Route("api/private/keysystems/erp/contasAPagar/tipoTitulo")]
    [ApiController]
    public class TipoTituloController : ControllerBase
    {
        private readonly TipoTituloService _tipoTituloService;
        private readonly IMapper _iMapper;

        public TipoTituloController(TipoTituloService tipoTituloService,
            IMapper iMapper)
        {
            _tipoTituloService = tipoTituloService;
            _iMapper = iMapper;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Get()
        {
            var result = _tipoTituloService.Get();
            var model = _iMapper.Map<List<TipoTituloModel>>(result);

            if (result.Any())
                return Ok(model);

            return NotFound();
        }
    }
}