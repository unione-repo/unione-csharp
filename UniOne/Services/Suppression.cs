using AutoMapper;
using Newtonsoft.Json;
using Serilog;
using UniOne.Models;

namespace UniOne;

public class Suppression
{
    private readonly IApiConnection _apiConnection;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private ErrorData _error;

    public Suppression(IApiConnection apiConnection, IMapper mapper, ILogger logger)
    {
        _apiConnection = apiConnection;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<SuppressionData> Set(string email, string cause, DateTime created)
    {
        _error = null;
        if(_apiConnection.IsLoggingEnabled())
            _logger.Information("Suppression:Set:email["+email+"]:cause[" + cause+"]:created["+created.ToUniversalTime()+"]");

        string response = "";
        var apiResponse = await _apiConnection.SendMessageAsync("suppression/set.json", SuppressionInputData.CreateNew(email,cause,created));
        if (!apiResponse.Item1.ToLower().Contains("error"))
        {
            var result = OperationResult<SuppressionData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Suppression:Set:result:" + result.GetStatus());
            
            var mappedResult = _mapper.Map<SuppressionData>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Suppression:Set:END");

            return mappedResult;
        }
        else
        {
            var result = OperationResult<ErrorData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Suppression:Set:result:" + result.GetStatus());
           
            _error = _mapper.Map<ErrorData>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Suppression:Set:END");

            return null;
        }
    }
    
    public async Task<SuppressionData> Get(string email, bool all_projects)
    {
        _error = null;
        if(_apiConnection.IsLoggingEnabled())
            _logger.Information("Suppression:Get:email["+email+"]:all_projects[" + all_projects + "]");

        string response = "";
        var apiResponse = await _apiConnection.SendMessageAsync("suppression/get.json", SuppressionInputData.CreateNew(email,null,DateTime.MinValue,all_projects));
        if (!apiResponse.Item1.ToLower().Contains("error"))
        {
            var result = OperationResult<SuppressionData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Suppression:Get:result:" + result.GetStatus());
            
            var mappedResult = _mapper.Map<SuppressionData>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Suppression:Get:END");

            return mappedResult;
        }
        else
        {
            var result = OperationResult<ErrorData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Suppression:Get:result:" + result.GetStatus());
           
            _error = _mapper.Map<ErrorData>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Suppression:Get:END");

            return null;
        }
    }
    
    public async Task<SuppressionData> List(string cause ="" , string source = "" , DateTime? start_time = null, string cursor = "", int limit = 50)
    {
        _error = null;
        if(_apiConnection.IsLoggingEnabled())
            _logger.Information("Suppression:List");

        string response = "";
        var apiResponse = await _apiConnection.SendMessageAsync("suppression/get.json", new SuppressionListFilters(cause,source,start_time,cursor,limit));
        if (!apiResponse.Item1.ToLower().Contains("error"))
        {
            var result = OperationResult<SuppressionData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Suppression:List:result:" + result.GetStatus());
            
            var mappedResult = _mapper.Map<SuppressionData>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Suppression:List:END");

            return mappedResult;
        }
        else
        {
            var result = OperationResult<ErrorData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Suppression:List:result:" + result.GetStatus());
           
            _error = _mapper.Map<ErrorData>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Suppression:List:END");

            return null;
        }
    }
    
    public async Task<SuppressionData> Delete(string email)
    {
        _error = null;
        if(_apiConnection.IsLoggingEnabled())
            _logger.Information("Suppression:Delete:email["+email+"]");

        string response = "";
        var apiResponse = await _apiConnection.SendMessageAsync("suppression/delete.json", SuppressionInputData.CreateNew(email));
        if (!apiResponse.Item1.ToLower().Contains("error"))
        {
            var result = OperationResult<SuppressionData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Suppression:Delete:result:" + result.GetStatus());
            
            var mappedResult = _mapper.Map<SuppressionData>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Suppression:Delete:END");

            return mappedResult;
        }
        else
        {
            var result = OperationResult<ErrorData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Suppression:Delete:result:" + result.GetStatus());
           
            _error = _mapper.Map<ErrorData>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Suppression:Delete:END");

            return null;
        }
    }
    
    public ErrorData GetError() => _error;
}