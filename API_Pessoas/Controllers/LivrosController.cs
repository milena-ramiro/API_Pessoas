using API_Pessoas.Business;
using API_Pessoas.Data.VO;
using API_Pessoas.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API_Pessoas.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class LivrosController : ControllerBase
    {
        private ILivroBusiness _livro;
        private readonly ILogger<LivrosController> _logger;
        
        
        public LivrosController(ILogger<LivrosController> logger, ILivroBusiness livro)
        {
            _logger = logger;
            _livro = livro;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_livro.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var livro = _livro.FindByID(id);
            if (livro == null) return NotFound();
            return Ok(_livro.FindByID(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] LivroVO livro)
        {
            if (livro == null) return BadRequest();
            return Ok(_livro.Create(livro));
        }

        [HttpPut]
        public IActionResult Put([FromBody] LivroVO livro)
        {
            if (livro == null) return BadRequest();
            return Ok(_livro.Update(livro));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _livro.Delete(id);
            return NoContent();
        }
        
        
    }
}