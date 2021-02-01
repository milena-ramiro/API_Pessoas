﻿using API_Pessoas.Business;
using API_Pessoas.Data.VO;
using API_Pessoas.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API_Pessoas.Controllers
{
    [ApiVersion("1")]
    [ApiController]
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
        public IActionResult Post([FromBody] PessoaVO pessoa)
        {
            if (pessoa == null) return BadRequest();
            return Ok(_pessoa.Create(pessoa));
        }

        [HttpPut]
        public IActionResult Put([FromBody] PessoaVO pessoa)
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
