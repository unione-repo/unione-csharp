using AutoMapper;
using Newtonsoft.Json;
using Serilog;
using UniOne.Models;

namespace UniOne;

public class EmailValidation
{
    private readonly IApiConnection _apiConnection;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private ErrorData?_error;

    public EmailValidation(IApiConnection apiConnection, IMapper mapper,ILogger logger)
    {
        _apiConnection = apiConnection;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<EmailValidationData> ValidationSingle(string emailAddress)
    {
        _error = null;
        if(_apiConnection.IsLoggingEnabled())
            _logger.Information("EmailValidation:ValidationSingle:emailAddress["+emailAddress+"]");
        
        var apiResponse = await _apiConnection.SendMessageAsync("email-validation/single.json", EmailAddressData.CreateNew(emailAddress));
        if (!apiResponse.Item1.ToLower().Contains("error") && !apiResponse.Item2.ToLower().Contains("error") && !apiResponse.Item1.ToLower().Contains("cancelled"))
        {
            var result = OperationResult<EmailValidationData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("EmailValidation:ValidationSingle:result:" + result.GetStatus());
            
            var mappedResult = _mapper.Map<EmailValidationData>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("EmailValidation:ValidationSingle:END");

            return mappedResult;
        }
        else
        {
            var result = OperationResult<ErrorDetailsData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("EmailValidation:ValidationSingle:result:" + result.GetStatus());
           
            this._error = new ErrorData();
            this._error.Status = apiResponse.Item1;
            this._error.Details = _mapper.Map<ErrorDetailsData>(result.GetResponse());
            this._error.Details.CodeDescription = ApiErrorData.GetError(this._error.Details.Code); 
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("EmailValidation:ValidationSingle:END");

            return null!;
        }
    }
    
    public ErrorData? GetError() => _error;
}