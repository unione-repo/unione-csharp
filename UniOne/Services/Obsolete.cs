using UniOne.Models;
using AutoMapper;
using Newtonsoft.Json;
using Serilog;

namespace UniOne;

public class Obsolete
{
    private readonly IApiConnection _apiConnection;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private ErrorData _error;

    public Obsolete(IApiConnection apiConnection, IMapper mapper, ILogger logger)
    {
        _apiConnection = apiConnection;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<UnsubscribedData> UnsubscribedSet(string emailAddress)
    {
        _error = null;
        if(_apiConnection.IsLoggingEnabled())
            _logger.Information("Obsolete:UnsubscribedSet:emailAddress[" + emailAddress +"]");

        string response = "";
        var apiResponse = await _apiConnection.SendMessageAsync("unsubscribed/set.json", EmailAddressData.CreateNew(emailAddress));
        if (!apiResponse.Item1.ToLower().Contains("error"))
        {
            var result = OperationResult<UnsubscribedData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Obsolete:UnsubscribedSet:result:" + result.GetStatus());
            
            var mappedResult = _mapper.Map<UnsubscribedData>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Obsolete:UnsubscribedSet:END");

            return mappedResult;
        }
        else
        {
            var result = OperationResult<ErrorData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Obsolete:UnsubscribedSet:result:" + result.GetStatus());
           
            _error = _mapper.Map<ErrorData>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Obsolete:UnsubscribedSet:END");

            return null;
        }
    }

    public async Task<UnsubscribedData> UnsubscribedCheck(string emailAddress)
    {
        _error = null;
        if(_apiConnection.IsLoggingEnabled())
            _logger.Information("Obsolete:UnsubscribedCheck:emailAddress[" + emailAddress +"]");

        string response = "";
        var apiResponse = await _apiConnection.SendMessageAsync("unsubscribed/check.json", EmailAddressData.CreateNew(emailAddress));
        if (!apiResponse.Item1.ToLower().Contains("error"))
        {
            var result = OperationResult<UnsubscribedData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Obsolete:UnsubscribedCheck:result:" + result.GetStatus());
            
            var mappedResult = _mapper.Map<UnsubscribedData>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Obsolete:UnsubscribedCheck:END");

            return mappedResult;
        }
        else
        {
            var result = OperationResult<ErrorData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Obsolete:UnsubscribedCheck:result:" + result.GetStatus());
           
            _error = _mapper.Map<ErrorData>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Obsolete:UnsubscribedCheck:END");

            return null;
        }
    }

    public async Task<UnsubscribedList> UnsubscribedList(string emailAddress)
    {
        _error = null;
        if(_apiConnection.IsLoggingEnabled())
            _logger.Information("Obsolete:UnsubscribedList:emailAddress[" + emailAddress +"]");

        string response = "";
        var apiResponse = await _apiConnection.SendMessageAsync("unsubscribed/list.json", EmailAddressData.CreateNew(emailAddress));
        if (!apiResponse.Item1.ToLower().Contains("error"))
        {
            var result = OperationResult<UnsubscribedList>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Obsolete:UnsubscribedList:result:" + result.GetStatus());
           
            var mappedResult = _mapper.Map<UnsubscribedList>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Obsolete:UnsubscribedList:END");

            return mappedResult;
        }
        else
        {
            var result = OperationResult<ErrorData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Obsolete:UnsubscribedList:result:" + result.GetStatus());
           
            _error = _mapper.Map<ErrorData>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Obsolete:UnsubscribedList:END");

            return null;
        }
    }
    
    public ErrorData GetError() => _error;
}