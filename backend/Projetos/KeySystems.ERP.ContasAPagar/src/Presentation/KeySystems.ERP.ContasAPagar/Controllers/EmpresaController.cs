using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using KeySystems.ERP.ContasAPagar.Core.Application.Empresa;
using KeySystems.ERP.ContasAPagar.Models;
using Microsoft.AspNetCore.Mvc;

namespace KeySystems.ERP.ContasAPagar.Controllers
{
    [Route("api/private/keysystems/erp/ContasAPagar/empresa")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IMapper _iMapper;
        private readonly EmpresaService _empresaService;

        public EmpresaController(IMapper iMapper,
            EmpresaService empresaService)
        {
            _iMapper = iMapper;
            _empresaService = empresaService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            var entity = _empresaService.Get();
            var model = _iMapper.Map<IEnumerable<EmpresaModel>>(entity);

            if (!model.Any())
                return NotFound();

            return Ok(model);
        }
    }
}