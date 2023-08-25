namespace UniOne;

public interface IApiConfiguration
{
    string GetApiUrl();
    string GetApiKey();
    bool IsLoggingEnabled();
    int GetTimeout();

}