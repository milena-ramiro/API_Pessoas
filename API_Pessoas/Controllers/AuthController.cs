using API_Pessoas.Business;
using API_Pessoas.Data.VO;
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
        public IActionResult SigIn([FromBody] UsuarioVO user)
        {
            if (user == null) return BadRequest("Invalid Client Request");
            var token = _business.ValidateCredentials(user);
            if (token == null) return Unauthorized();
            return Ok(token);
        }
        
        
    }
}