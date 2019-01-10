using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using KeySystems.ERP.ContasAPagar.Core.Application.ContasAPagar.TipoPgto;
using KeySystems.ERP.ContasAPagar.Models;
using Microsoft.AspNetCore.Mvc;

namespace KeySystems.ERP.ContasAPagar.Controllers
{
    [Route("api/private/keysystems/erp/contasAPagar/tipoPgto")]
    [ApiController]
    public class TipoPgtoController : ControllerBase
    {
        private readonly TipoPgtoService _tipoPgtoService;
        private readonly IMapper _iMapper;

        public TipoPgtoController(TipoPgtoService tipoPgtoService, IMapper iMapper)
        {
            _tipoPgtoService = tipoPgtoService;
            _iMapper = iMapper;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Get()
        {
            var result = _tipoPgtoService.Get();
            var model = _iMapper.Map<List<TipoPgtoModel>>(result);

            if (result.Any())
                return Ok(model);

            return NotFound();
        }
    }
}