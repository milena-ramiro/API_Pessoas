using System;
using API_Pessoas.Configurations;
using API_Pessoas.Repository;
using API_Pessoas.Services;
using Moq;
using Xunit;

namespace Test
{
    public class Authorization
    {
        [Fact]
        public void CommandIsValid_Executed_Succes()
        {
            var tokenConfiguration = new TokenConfiguration
            {
                Audience = "ExampleAudience",
                Issuer = "ExampleIssuer",
                Secret = "MY_SUPER_SECRET_KEY",
                Minutes = 60,
                DaysToExpiry = 7
            };

            var userRepository = new Mock<IUserRepository>();
            var tokenService = new Mock<ITokenService>();

        }
    }
}