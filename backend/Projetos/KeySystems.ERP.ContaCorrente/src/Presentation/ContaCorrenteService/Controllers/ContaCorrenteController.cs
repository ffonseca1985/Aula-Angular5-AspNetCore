using Microsoft.AspNetCore.Mvc;

namespace ContaCorrenteService.Controllers
{
    using KeySystems.ERP.ContaCorrente.Core.Application.ContaCorrente;
    using KeySystems.ERP.ContaCorrente.Core.Application.ContaCorrente.Dtos;
    using System;

    [Route("api/contaCorrente/{codigoEmpresa}")]
    public class ContaCorrenteController
        : Controller
    {
        private readonly ContaCorrenteService _contaCorrenteService;

        public ContaCorrenteController(ContaCorrenteService contaCorrenteService)
        {
            _contaCorrenteService = contaCorrenteService;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Add( int codigoEmpresa,
                [FromBody]ContaCorrenteRequest request)
        {
            if (request == null || codigoEmpresa == default(int))
                BadRequest();

            _contaCorrenteService.Add(request);

            return CreatedAtRoute("GetByGrupoSubGrupoNumero", 
                new {
                    grupo = request.Grupo,
                    subgrupo = request.SubGrupo,
                    numero = request.Numero    
                }, 
                request);
        }

        [HttpGet]
        [Route("{grupo}/{subGrupo}/{numero}/{codigoEmpresa}", Name = "GetByGrupoSubGrupoNumero")]
        public IActionResult Get(int grupo, int subgrupo, int numero, int codigoEmpresa)
        {
            var response = _contaCorrenteService.Get(grupo, subgrupo, numero, codigoEmpresa);
            if (response == null)
                return NotFound();

            return Ok(response);
        }


        [HttpPost]
        [Route("{idContaCorrente}/lancamento")]
        public IActionResult Post([FromQuery]Guid idContaCorrente, [FromBody]LancamentoRequest request)
        {
            if (idContaCorrente == default(Guid) || request == null)
                return BadRequest();

            _contaCorrenteService.AddLancamento(idContaCorrente, request);

            return Ok();
        }
    }
}
