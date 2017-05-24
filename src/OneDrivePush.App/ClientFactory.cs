using System;

namespace OneDrivePush
{
    public class ClientFactory : IClientFactory
    {
        public IClientApplication CreateClientApplication(string appId)
        {
            if(string.IsNullOrEmpty(appId))
            {
                throw new ArgumentNullException("appId");
            }

            return new ClientApplication(appId);
        }
    }
}
