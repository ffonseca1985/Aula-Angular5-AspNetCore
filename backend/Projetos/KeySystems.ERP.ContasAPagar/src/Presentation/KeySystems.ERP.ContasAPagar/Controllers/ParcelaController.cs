using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KeySystems.ERP.ContasAPagar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelaController : ControllerBase
    {
        IMapper _mapper;

        public ParcelaController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [Route("ordem/{ordem}")]
        [HttpGet]
        public IActionResult Get(Guid tituloId, int ordem)
        {
            return Ok();
        }

        [Route("datavencimento/{dataVencimento}")]
        [HttpGet]
        public IActionResult Get(Guid tituloId, DateTime dataVencimento)
        {
            return Ok();
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult Get(Guid tituloId, Guid id)
        {
            return Ok();
        }

        [HttpPatch]
        [Route("")]
        public IActionResult Path(Guid tituloId, [FromBody] object dadosPagto)
        {
            return NoContent();
        }
    }
}