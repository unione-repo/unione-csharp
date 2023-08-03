namespace UniOne;

public interface IApiConnection
{
    string SendMessage(string command, object requestBody, out string apiResponse);
}