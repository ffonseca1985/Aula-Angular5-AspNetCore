using AutoMapper;
using KeySystems.ERP.ContasAPagar.Core.Application.Fornecedor;
using KeySystems.ERP.ContasAPagar.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace KeySystems.ERP.ContasAPagar.Controllers
{
    [Route("api/private/keysystems/erp/ContasAPagar/fornecedor")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IMapper _iMapper;
        private readonly FornecedorService _fornecedorService;

        public FornecedorController(IMapper iMapper,
            FornecedorService fornecedorService)
        {
            _iMapper = iMapper;
            _fornecedorService = fornecedorService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            var entity = _fornecedorService.Get();
            var model = _iMapper.Map<IEnumerable<FornecedorModel>>(entity);

            if (!model.Any())
                return NotFound();

            return Ok(model);
        }
    }
}