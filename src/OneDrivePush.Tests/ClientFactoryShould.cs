using Shouldly;
using System;
using Xunit;

namespace OneDrivePush.Tests
{
    public class ClientFactoryShould
    {
        IClientFactory _clientFactory;

        public ClientFactoryShould()
        {
            _clientFactory = new ClientFactory();
        }

        [Fact]
        public void Create_client_application_given_application_id()
        {
            IClientApplication clientApplitcation = _clientFactory.CreateClientApplication("some_id");

            clientApplitcation.ShouldBeOfType<ClientApplication>();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Throw_exception_when_app_id_is_not_supplied(string appId)
        {
            Should.Throw<ArgumentNullException>(() => _clientFactory.CreateClientApplication(appId));
        }
    }
}
