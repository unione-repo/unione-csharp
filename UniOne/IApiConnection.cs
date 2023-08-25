namespace UniOne;

public interface IApiConnection
{
    Task<(string,string)> SendMessageAsync(string command, object requestBody);
    bool IsLoggingEnabled();
}