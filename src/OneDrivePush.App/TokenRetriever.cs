using Microsoft.Identity.Client;
using System;
using System.Threading.Tasks;

namespace OneDrivePush
{
    public class TokenRetriever
    {
        private IClientApplication _clientApplication;

        public TokenRetriever(IClientApplication clientApplication)
        {
            _clientApplication = clientApplication;
        }

        public async Task<string> AquireTokenAsync()
        {
            try
            {
                return await _clientApplication.AquireTokenSilentlyAsync();
            }
            catch (Exception)
            {
                return await _clientApplication.AquireTokenAsync();
            }
        }
    }
}
