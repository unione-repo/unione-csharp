namespace UniOne;

public interface IOperationResult
{
    string GetStatus();
    string GetMessage();
    dynamic GetResponse();
}