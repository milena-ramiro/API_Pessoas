using System.Collections.Generic;
using API_Pessoas.Business;
using API_Pessoas.Data.VO;
using API_Pessoas.HyperMedia.Filters;
using API_Pessoas.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API_Pessoas.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PessoasController : ControllerBase
    {
        private IPessoaBusiness _pessoa;

        private readonly ILogger<PessoasController> _logger;

        public PessoasController(ILogger<PessoasController> logger, IPessoaBusiness pessoa)
        {
            _logger = logger;
            _pessoa = pessoa;
        }
        
        

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<PessoaVO>))]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [TypeFilter(typeof(HypermediaFilter))]
        public IActionResult Get()
        {
            return Ok(_pessoa.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(PessoaVO))]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [TypeFilter(typeof(HypermediaFilter))]
        public IActionResult Get(long id)
        {
            var person = _pessoa.FindByID(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(PessoaVO))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [TypeFilter(typeof(HypermediaFilter))]
        public IActionResult Post([FromBody] PessoaVO pessoa)
        {
            if (pessoa == null) return BadRequest();
            return Ok(_pessoa.Create(pessoa));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(PessoaVO))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [TypeFilter(typeof(HypermediaFilter))]
        public IActionResult Put([FromBody] PessoaVO pessoa)
        {
            if (pessoa == null) return BadRequest();
            return Ok(_pessoa.Update(pessoa));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        public IActionResult Delete(long id)
        {
            _pessoa.Delete(id);
            return NoContent();
        }

    }
}
