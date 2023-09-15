using AutoMapper;
using Newtonsoft.Json;
using Serilog;
using UniOne.Models;

namespace UniOne;

public class EventDump
{
    private readonly IApiConnection _apiConnection;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private ErrorData _error;

    public EventDump(IApiConnection apiConnection, IMapper mapper, ILogger logger)
    {
        _apiConnection = apiConnection;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<IOperationResult<string>> Create(EventDumpRequest request)
    {
        _error = null;
        if(_apiConnection.IsLoggingEnabled())
            _logger.Information("EventDump:Create");

        string response = "";
        var apiResponse = await _apiConnection.SendMessageAsync("event-dump/create.json", request);
        if (!apiResponse.Item1.ToLower().Contains("error") && !apiResponse.Item2.ToLower().Contains("error") && !apiResponse.Item1.ToLower().Contains("cancelled"))
        {
            var result = OperationResult<string>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("EventDump:Create:result:" + result.GetStatus());
            
            var mappedResult = _mapper.Map<string>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("EventDump:Create:END");

            return mappedResult;
        }
        else
        {
            var result = OperationResult<ErrorDetailsData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("EventDump:Create:result:" + result.GetStatus());
           
            this._error = new ErrorData();
            this._error.Status = apiResponse.Item1;
            this._error.Details = _mapper.Map<ErrorDetailsData>(result.GetResponse());
            this._error.Details.CodeDescription = ApiErrorData.GetError(this._error.Details.Code); 
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("EventDump:Create:END");

            return null;
        }
    }
    
    public async Task<EventDumpRequest> Get(string dumpId)
    {
        _error = null;
        if(_apiConnection.IsLoggingEnabled())
            _logger.Information("EventDump:Get:dumpId[" + dumpId +"]");

        string response = "";
        var apiResponse = await _apiConnection.SendMessageAsync("event-dump/get.json", "{ \"dump_id:\" \""+ dumpId + " \"  }");
        if (!apiResponse.Item1.ToLower().Contains("error") && !apiResponse.Item2.ToLower().Contains("error") && !apiResponse.Item1.ToLower().Contains("cancelled"))
        {
            var result = OperationResult<EventDumpRequest>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("EventDump:Get:result:" + result.GetStatus());
            
            var mappedResult = _mapper.Map<EventDumpRequest>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("EventDump:Get:END");

            return mappedResult;
        }
        else
        {
            var result = OperationResult<ErrorDetailsData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("EventDump:Get:result:" + result.GetStatus());
           
            this._error = new ErrorData();
            this._error.Status = apiResponse.Item1;
            this._error.Details = _mapper.Map<ErrorDetailsData>(result.GetResponse());
            this._error.Details.CodeDescription = ApiErrorData.GetError(this._error.Details.Code); 
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("EventDump:Get:END");

            return null;
        }
    }
    
    public async Task<EventDumpList> List(int limit = 50, int offset = 0)
    {
        _error = null;
        if(_apiConnection.IsLoggingEnabled())
            _logger.Information("EventDump:List:limit["+limit+"]:offset["+offset+"]");

        string response = "";
        var apiResponse = await _apiConnection.SendMessageAsync("event-dump/list.json", InputData.CreateNew(null,limit,offset));
        if (!apiResponse.Item1.ToLower().Contains("error") && !apiResponse.Item2.ToLower().Contains("error") && !apiResponse.Item1.ToLower().Contains("cancelled"))
        {
            var result = OperationResult<EventDumpList>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("EventDump:List:result:" + result.GetStatus());
            
            var mappedResult = _mapper.Map<EventDumpList>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("EventDump:List:END");

            return mappedResult;
        }
        else
        {
            var result = OperationResult<ErrorDetailsData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("EventDump:List:result:" + result.GetStatus());
           
            this._error = new ErrorData();
            this._error.Status = apiResponse.Item1;
            this._error.Details = _mapper.Map<ErrorDetailsData>(result.GetResponse());
            this._error.Details.CodeDescription = ApiErrorData.GetError(this._error.Details.Code); 
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("EventDump:List:END");

            return null;
        }
    }
    
    public async Task<IOperationResult<string>> Detele(string dumpId)
    {
        _error = null;
        if(_apiConnection.IsLoggingEnabled())
            _logger.Information("EventDump:Detele[" + dumpId +"]");

        string response = "";
        var apiResponse = await _apiConnection.SendMessageAsync("event-dump/delete.json", "{ \"dump_id:\" \""+ dumpId + " \"  }");
        if (!apiResponse.Item1.ToLower().Contains("error") && !apiResponse.Item2.ToLower().Contains("error") && !apiResponse.Item1.ToLower().Contains("cancelled"))
        {
            var result = OperationResult<string>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("EventDump:Detele:result:" + result.GetStatus());
            
            var mappedResult = _mapper.Map<string>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("EventDump:Detele:END");

            return mappedResult;
        }
        else
        {
            var result = OperationResult<ErrorDetailsData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("EventDump:Detele:result:" + result.GetStatus());
           
            this._error = new ErrorData();
            this._error.Status = apiResponse.Item1;
            this._error.Details = _mapper.Map<ErrorDetailsData>(result.GetResponse());
            this._error.Details.CodeDescription = ApiErrorData.GetError(this._error.Details.Code); 
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("EventDump:Detele:END");

            return null;
        }
    }
    
    public ErrorData GetError() => _error;
}