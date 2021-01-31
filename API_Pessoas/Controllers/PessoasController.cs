using API_Pessoas.Model;
using API_Pessoas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API_Pessoas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoasController : ControllerBase
    {
        private IPessoaService _pessoa;

        private readonly ILogger<PessoasController> _logger;

        public PessoasController(ILogger<PessoasController> logger, IPessoaService pessoa)
        {
            _logger = logger;
            _pessoa = pessoa;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pessoa.FindAll());
        }



        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _pessoa.FindByID(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] tbPessoa pessoa)
        {
            if (pessoa == null) return BadRequest();
            return Ok(_pessoa.Create(pessoa));
        }

        [HttpPut]
        public IActionResult Put([FromBody] tbPessoa pessoa)
        {
            if (pessoa == null) return BadRequest();
            return Ok(_pessoa.Update(pessoa));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _pessoa.Delete(id);
            return NoContent();
        }

    }
}
