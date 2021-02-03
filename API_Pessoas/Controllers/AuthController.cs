using API_Pessoas.Business;
using API_Pessoas.Data.VO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Pessoas.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class AuthController : Controller
    {
        private ILoginBusiness _business;

        public AuthController(ILoginBusiness business)
        {
            _business = business;
        }
        
        [HttpPost]
        [Route("sigin")]
        public IActionResult SigIn([FromBody] UsuarioVO tokenVO)
        {
            if (tokenVO == null) return BadRequest("Invalid Client Request");
            var token = _business.ValidateCredentials(tokenVO);
            if (token == null) return Unauthorized();
            return Ok(token);
        }
        
        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh([FromBody] TokenVO tokenVO)
        {
            if (tokenVO == null) return BadRequest("Invalid Client Request");
            var token = _business.ValidateCredentials(tokenVO);
            if (token == null) return BadRequest("Invalid Client Request");
            return Ok(token);
        }
        
        
        //FAZER LOG OFF DA APLICAÇÃO
        [HttpGet]
        [Authorize("Bearer")]
        [Route("revoke")]
        public IActionResult Revoke()
        {
            var username = User.Identity.Name;
            var result = _business.RevokeToken(username);
            
            if (!result) return BadRequest("Invalid Client Request");
            return NoContent();
        }
        
        
        
    }
}