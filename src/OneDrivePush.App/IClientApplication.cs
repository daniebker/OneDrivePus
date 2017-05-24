using System.Threading.Tasks;

namespace OneDrivePush
{
    public interface IClientApplication
    {
        Task<string> AquireTokenAsync();
        Task<string> AquireTokenSilentlyAsync();
    }
}
