using AutoMapper;
using Newtonsoft.Json;
using Serilog;
using UniOne.Models;

namespace UniOne;

public class Tag
{
    private readonly IApiConnection _apiConnection;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private ErrorData _error;

    public Tag(IApiConnection apiConnection, IMapper mapper, ILogger logger)
    {
        _apiConnection = apiConnection;
        _mapper = mapper;
        _logger = logger;
    }
    
    public async Task<TagList> List()
    {
        _error = null;
        if(_apiConnection.IsLoggingEnabled())
            _logger.Information("Tag:List");

        string response = "";
        var apiResponse = await _apiConnection.SendMessageAsync("tag/list.json", "{ }");
        if (!apiResponse.Item1.ToLower().Contains("error") && !apiResponse.Item2.ToLower().Contains("error") && !apiResponse.Item1.ToLower().Contains("cancelled"))
        {
            var result = OperationResult<TagList>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Tag:List:result:" + result.GetStatus());
            
            var mappedResult = _mapper.Map<TagList>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Tag:List:END");

            return mappedResult;
        }
        else
        {
            var result = OperationResult<ErrorDetailsData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Tag:List:result:" + result.GetStatus());
           
            this._error = new ErrorData();
            this._error.Status = apiResponse.Item1;
            this._error.Details = _mapper.Map<ErrorDetailsData>(result.GetResponse());
            this._error.Details.CodeDescription = ApiErrorData.GetError(this._error.Details.Code); 
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Tag:List:END");

            return null;
        }
    }
    
    public async Task<IOperationResult<string>> Detele(int tagId)
    {
        _error = null;
        if(_apiConnection.IsLoggingEnabled())
            _logger.Information("Tag:Delete:tagId["+tagId+"]");

        string response = "";
        var apiResponse = await _apiConnection.SendMessageAsync("tag/delete.json", TagData.CreateNew(tagId,""));
        if (!apiResponse.Item1.ToLower().Contains("error") && !apiResponse.Item2.ToLower().Contains("error") && !apiResponse.Item1.ToLower().Contains("cancelled"))
        {
            var result = OperationResult<string>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Tag:Delete:result:" + result.GetStatus());
            
            var mappedResult = _mapper.Map<string>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Tag:Delete:END");

            return mappedResult;
        }
        else
        {
            var result = OperationResult<ErrorDetailsData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Tag:Delete:result:" + result.GetStatus());
           
            this._error = new ErrorData();
            this._error.Status = apiResponse.Item1;
            this._error.Details = _mapper.Map<ErrorDetailsData>(result.GetResponse());
            this._error.Details.CodeDescription = ApiErrorData.GetError(this._error.Details.Code); 
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Tag:Delete:END");

            return null;
        }
    }
    
    public ErrorData GetError() => _error;
}