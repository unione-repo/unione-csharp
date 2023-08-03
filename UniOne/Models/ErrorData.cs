namespace UniOne.Models;

public class ErrorData
{
    private string _status { get; set; }
    private string _message { get; set; }
    private int _errorCode { get; set; }

    public string Status => _status;
    public string Message => _message;
    public int ErrorCode => _errorCode;
    
    private ErrorData(){}

    private ErrorData(string status, string message, int errorCode)
    {
        _status = status;
        _message = message;
        _errorCode = errorCode;
    }

    public static ErrorData CreateNew(string status, string message, int errorCode)
    {
        return new ErrorData(status, message, errorCode);
    }
}