using System.Threading.Tasks;

namespace OneDrivePush.App
{
    public interface IHttpHandler
    {
        Task<string> GetAsync(string resource);
    }
}
