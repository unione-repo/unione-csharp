using AutoMapper;
using Newtonsoft.Json;
using Serilog;
using UniOne.Models;

namespace UniOne;

public class Template
{
    private readonly IApiConnection _apiConnection;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private ErrorData _error;

    public Template(IApiConnection apiConnection, IMapper mapper, ILogger logger)
    {
        _apiConnection = apiConnection;
        _mapper = mapper;
        _logger = logger;
    }
    
    public async Task<IOperationResult<string>> Set(TemplateData templateData)
    {
        _error = null;
        if(_apiConnection.IsLoggingEnabled())
            _logger.Information("Template:Set");

        string response = "";
        var apiResponse = await _apiConnection.SendMessageAsync("template/set.json", templateData.ToJson());
        if (!apiResponse.Item1.ToLower().Contains("error") && !apiResponse.Item2.ToLower().Contains("error") && !apiResponse.Item1.ToLower().Contains("cancelled"))
        {
            var result = OperationResult<string>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Template:Set:result:" + result.GetStatus());
            
            var mappedResult = _mapper.Map<string>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Template:Set:END");

            return mappedResult;
        }
        else
        {
            var result = OperationResult<ErrorDetailsData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Template:Set:result:" + result.GetStatus());
           
            this._error = new ErrorData();
            this._error.Status = apiResponse.Item1;
            this._error.Details = _mapper.Map<ErrorDetailsData>(result.GetResponse());
            this._error.Details.CodeDescription = ApiErrorData.GetError(this._error.Details.Code); 
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Template:Set:END");

            return null;
        }
    }

    public async Task<TemplateData> Get(string id)
    {
        _error = null;
        if(_apiConnection.IsLoggingEnabled())
            _logger.Information("Template:Get:id[" + id +"]");

        string response = "";
        var apiResponse = await _apiConnection.SendMessageAsync("template/get.json", InputData.CreateNew(id,null,null));
        if (!apiResponse.Item1.ToLower().Contains("error") && !apiResponse.Item2.ToLower().Contains("error") && !apiResponse.Item1.ToLower().Contains("cancelled"))
        {
            var result = OperationResult<TemplateData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Template:Get:result:" + result.GetStatus());
           
            var mappedResult = _mapper.Map<TemplateData>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Template:Get:END");

            return mappedResult;
        }
        else
        {
            var result = OperationResult<ErrorDetailsData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Template:Get:result:" + result.GetStatus());
           
            this._error = new ErrorData();
            this._error.Status = apiResponse.Item1;
            this._error.Details = _mapper.Map<ErrorDetailsData>(result.GetResponse());
            this._error.Details.CodeDescription = ApiErrorData.GetError(this._error.Details.Code); 
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Template:Get:END");

            return null;
        }
    }
    
    public async Task<TemplateList> List(int limit = 50, int offset = 0)
    {
        _error = null;
        if(_apiConnection.IsLoggingEnabled())
            _logger.Information("Template:List:limit["+limit+"]:offset["+offset+"]");

        string response = "";
        var apiResponse = await _apiConnection.SendMessageAsync("template/list.json", InputData.CreateNew(null,limit,offset));
        if (!apiResponse.Item1.ToLower().Contains("error") && !apiResponse.Item2.ToLower().Contains("error") && !apiResponse.Item1.ToLower().Contains("cancelled"))
        {
            var result = OperationResult<TemplateList>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Template:List:result:" + result.GetStatus());
            
            var mappedResult = _mapper.Map<TemplateList>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Template:List:END");

            return mappedResult;
        }
        else
        {
            var result = OperationResult<ErrorDetailsData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Template:List:result:" + result.GetStatus());
            
            this._error = new ErrorData();
            this._error.Status = apiResponse.Item1;
            this._error.Details = _mapper.Map<ErrorDetailsData>(result.GetResponse());
            this._error.Details.CodeDescription = ApiErrorData.GetError(this._error.Details.Code); 
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Template:List:END");

            return null;
        }
    }
    
    public async Task<IOperationResult<string>> Detele(string id)
    {
        _error = null;
        if(_apiConnection.IsLoggingEnabled())
            _logger.Information("Template:Detele:id[" + id +"]");

        string response = "";
        var apiResponse = await _apiConnection.SendMessageAsync("template/delete.json", InputData.CreateNew(id,null,null));
        if (!apiResponse.Item1.ToLower().Contains("error") && !apiResponse.Item2.ToLower().Contains("error") && !apiResponse.Item1.ToLower().Contains("cancelled"))
        {
            var result = OperationResult<string>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Template:Detele:result:" + result.GetStatus());
            
            var mappedResult = _mapper.Map<string>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Template:Detele:END");

            return mappedResult;
        }
        else
        {
            var result = OperationResult<ErrorDetailsData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Template:Detele:result:" + result.GetStatus());
           
            this._error = new ErrorData();
            this._error.Status = apiResponse.Item1;
            this._error.Details = _mapper.Map<ErrorDetailsData>(result.GetResponse());
            this._error.Details.CodeDescription = ApiErrorData.GetError(this._error.Details.Code); 
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Template:Detele:END");

            return null;
        }
    }
    
    public ErrorData GetError() => _error;
}