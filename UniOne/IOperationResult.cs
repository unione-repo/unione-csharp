namespace UniOne;

public interface IOperationResult
{
    string GetJobId();
    int GetErrorCode();
    string GetStatus();
    string GetMessage();
    object GetResponse();
}