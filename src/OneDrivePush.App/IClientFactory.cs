namespace OneDrivePush
{
    public interface IClientFactory
    {
        IClientApplication CreateClientApplication(string appId);
    }
}
