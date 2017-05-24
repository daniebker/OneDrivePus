using Xunit;
using Moq;
using System.Threading.Tasks;
using Shouldly;
using System;

namespace OneDrivePush.Tests
{
    public class TokeRetrieverShould
    {
        private Mock<IClientApplication> _clientApplicationMock;
        private TokenRetriever _tokenRetriever;

        public TokeRetrieverShould()
        {
            _clientApplicationMock = new Mock<IClientApplication>(MockBehavior.Strict);
            
            _tokenRetriever = new TokenRetriever(_clientApplicationMock.Object);
        }

        [Fact]
        public void Aquire_token_silently_without_user_prompt()
        {
            _clientApplicationMock
                .Setup(m => m.AquireTokenSilentlyAsync())
                .Returns(Task.FromResult("token"));

            string token = _tokenRetriever.AquireTokenAsync().Result;

            token.ShouldBe("token");
        }

        [Fact]
        public void Aquire_toke_via_user_input_when_fails_silently()
        {
            _clientApplicationMock
               .Setup(m => m.AquireTokenSilentlyAsync())
               .Throws<Exception>();

            _clientApplicationMock
                .Setup(m => m.AquireTokenAsync())
                .Returns(Task.FromResult<string>("token"));

            string token = _tokenRetriever.AquireTokenAsync().Result;

            token.ShouldBe("token");
        }
    }
}
