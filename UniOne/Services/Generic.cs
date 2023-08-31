using AutoMapper;
using Newtonsoft.Json;
using Serilog;
using UniOne.Models;

namespace UniOne;

public class Generic
{
    private readonly IApiConnection _apiConnection;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private ErrorData _error;

    public Generic(IApiConnection apiConnection, IMapper mapper, ILogger logger)
    {
        _apiConnection = apiConnection;
        _mapper = mapper;
        _logger = logger;
    }


    public async Task<T> CustomRequest<T>(string request, object obj)
    {
        _error = null;
        if(_apiConnection.IsLoggingEnabled())
            _logger.Information("Generic:CustomRequest");

        string response = "";
        var apiResponse = await _apiConnection.SendMessageAsync(request, obj);
        if (!apiResponse.Item1.ToLower().Contains("error"))
        {
            var result = OperationResult<object>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Generic:CustomRequest:" + result.GetStatus());
            
            var mappedResult = _mapper.Map<T>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Generic:CustomRequest:END");

            return mappedResult;
        }
        else
        {
            var result = OperationResult<ErrorData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Generic:CustomRequest:result:" + result.GetStatus());
           
            _error = _mapper.Map<ErrorData>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Generic:CustomRequest:END");

            return default(T);
        }
    }
    
    public ErrorData GetError() => _error;
}