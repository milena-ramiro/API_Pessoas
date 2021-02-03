using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using API_Pessoas.Configurations;
using API_Pessoas.Data.VO;
using API_Pessoas.Repository;
using API_Pessoas.Services;
using API_Pessoas.Services.Implementations;

namespace API_Pessoas.Business.Implementations
{
    public class LoginBusinessImplementation : ILoginBusiness
    {
        private const string DATE_FORMAT = "yyy-MM-dd HH:mm:ss";
        private TokenConfiguration _configuration;

        private IUserRepository _repository;
        private readonly ITokenService _service;

        public LoginBusinessImplementation(TokenConfiguration configuration, IUserRepository repository, ITokenService service)
        {
            _configuration = configuration;
            _repository = repository;
            _service = service;
        }


        public TokenVO ValidateCredentials(UsuarioVO userCredentials)
        {
            //Pegar credenciais e verificar se está tudo certo.
            var user = _repository.ValidateCredentials(userCredentials);
            if (user == null) return null;
            
            //gerar claims
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            //gerar token
            var accessToken = _service.GenerateAccessToken(claims);
            var refreshToken = _service.GenerateRefreshToken();

            //setando tokens gerados no usuario
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);
            
            //definir quando foi gerado token e quando vai expirar
            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

            //atualizando alterações do usuario
            _repository.RefreshUserInfo(user);
            
            //setando informações do token e retornando para o controller
            return new TokenVO(
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken
                );
        }

        
        public TokenVO ValidateCredentials(TokenVO token)
        {
            //gerar token
            var accessToken = token.AcessToken;
            var refreshToken = token.RefreshToken;

            var principal = _service.GetPrincipalFromExpiredToken(accessToken);
            var username = principal.Identity.Name;
            var user = _repository.ValidateCredentials(username);
            
            if (user == null || user.RefreshToken != refreshToken ||
                user.RefreshTokenExpiryTime >= DateTime.Now) return null;
            
            accessToken = _service.GenerateAccessToken(principal.Claims);
            refreshToken = _service.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            
            //definir quando foi gerado token e quando vai expirar
            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);
            
            //setando informações do token e retornando para o controller
            return new TokenVO(
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken
            );
        }

        public bool RevokeToken(string userName)
        {
            return _repository.RevokeToken(userName);
        }
    }
}