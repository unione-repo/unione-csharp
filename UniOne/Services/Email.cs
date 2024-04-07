using AutoMapper;
using Newtonsoft.Json;
using Serilog;
using UniOne.Models;

namespace UniOne;

public class Email
{
    private readonly IApiConnection _apiConnection;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private ErrorData? _error;

    public Email(IApiConnection apiConnection, IMapper mapper, ILogger logger)
    {
        _apiConnection = apiConnection;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<EmailResponseData> Send(EmailMessageData message)
    {
        _error = null;
        if(_apiConnection.IsLoggingEnabled())
            _logger.Information("Email:Send");
        
        var apiResponse = await _apiConnection.SendMessageAsync("email/send.json", message.ToJson());
        if (!apiResponse.Item1.ToLower().Contains("error") && !apiResponse.Item2.ToLower().Contains("error") && !apiResponse.Item1.ToLower().Contains("cancelled"))
        {
            var result = OperationResult<EmailResponseData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Email:Send:result:" + result.GetStatus());
            
            var mappedResult = _mapper.Map<EmailResponseData>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled()) 
                _logger.Information("Email:Send:END");

            return mappedResult;
        }
        else
        {
            var result = OperationResult<ErrorDetailsData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Email:Send:result:" + result.GetStatus());
           
            this._error = new ErrorData();
            this._error.Status = apiResponse.Item1;
            if (!this._error.Status.Contains("timeout"))
                this._error.Details = _mapper.Map<ErrorDetailsData>(result.GetResponse());
            else
                this._error.Details = ErrorDetailsData.CreateNew("TIMEOUT",apiResponse.Item1,0);
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Email:Send:END");

            return null!;
        }
    }
    
    public async Task<IOperationResult<string>> Subscribe(string fromEmail, string fromName, string toEmail)
    {
        _error = null;
        if(_apiConnection.IsLoggingEnabled())
            _logger.Information("Email:Subscribe:fromEmail["+fromEmail+"]:fromName[" + fromName +"]:toEmail["+toEmail+"]");
        
        var apiResponse = await _apiConnection.SendMessageAsync("email/send.json", EmailSubscribeData.CreateNew(fromEmail,fromName,toEmail));
        if (!apiResponse.Item1.ToLower().Contains("error") && !apiResponse.Item2.ToLower().Contains("error") && !apiResponse.Item1.ToLower().Contains("cancelled"))
        {
            var result = OperationResult<string>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Email:Subscribe:result:" + result.GetStatus());
            
            var mappedResult = _mapper.Map<EmailResponseData>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Email:Subscribe:END");

            return mappedResult;
        }
        else
        {
            var result = OperationResult<ErrorDetailsData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Email:Subscribe:result:" + result.GetStatus());
           
            this._error = new ErrorData();
            this._error.Status = apiResponse.Item1;
            if (!this._error.Status.Contains("timeout"))
                this._error.Details = _mapper.Map<ErrorDetailsData>(result.GetResponse());
            else
                this._error.Details = ErrorDetailsData.CreateNew("TIMEOUT", apiResponse.Item1, 0);

            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Email:Subscribe:END");

            return null!;
        }
    }
    
    public ErrorData? GetError() => _error;
}