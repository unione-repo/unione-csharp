using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace UniOne;

public class OperationResult<T> : IOperationResult<T> where T: class
{
    private dynamic _reponseBody { get; set; }
    private string _status { get; set; }

    public string GetStatus() => _status;
    
    public string GetMessage()
    {
        if (_reponseBody.message)
        {
            return _reponseBody.message;
        }
        
        return string.Empty;
    }

    public dynamic GetResponse() => _reponseBody;

    private OperationResult(){}
    private OperationResult(string status, dynamic responseBody)
    {
        _status = status;
        _reponseBody = responseBody;
    }

    public static OperationResult<T> CreateNew(string status, string responseBody)
    {
        var data = JsonConvert.DeserializeObject<T>(responseBody);
        
        return new OperationResult<T>(status, data);
    }
}