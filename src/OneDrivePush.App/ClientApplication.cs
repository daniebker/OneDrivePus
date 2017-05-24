using Microsoft.Identity.Client;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OneDrivePush
{
    public class ClientApplication : IClientApplication
    {
        public ClientApplication(string appId)
        {
            _publicClientApplication = new PublicClientApplication(appId, "https://login.microsoftonline.com/common/", CachePersistence.GetUserCache());
        }

        private string[] _scopes = { "Files.ReadWrite.All" };
        private PublicClientApplication _publicClientApplication;
        public static DateTimeOffset Expiration;
        private IUser _user;

        public string[] Scopes
        {
            get
            {
                return _scopes;
            }
            set
            {
                _scopes = value;
            }
        }

        public string Token { get; private set; }

        public async Task<string> AquireTokenAsync()
        {
            AuthenticationResult authResult = await _publicClientApplication.AcquireTokenAsync(Scopes).ConfigureAwait(false);
            _user = authResult.User;
            return authResult.AccessToken;
        }

        public async Task<string> AquireTokenSilentlyAsync()
        {
            AuthenticationResult authResult = await _publicClientApplication.AcquireTokenSilentAsync(Scopes, _publicClientApplication.Users.First()).ConfigureAwait(false);
            return authResult.AccessToken;
        }
    }
}