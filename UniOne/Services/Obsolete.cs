﻿using UniOne.Models;
using AutoMapper;
using Newtonsoft.Json;
using Serilog;

namespace UniOne;

public class Obsolete
{
    private readonly IApiConnection _apiConnection;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private ErrorData? _error;

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
        
        var apiResponse = await _apiConnection.SendMessageAsync("unsubscribed/set.json", EmailAddressData.CreateNew(emailAddress));
        if (!apiResponse.Item1.ToLower().Contains("error") && !apiResponse.Item2.ToLower().Contains("error") && !apiResponse.Item1.ToLower().Contains("cancelled"))
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
            var result = OperationResult<ErrorDetailsData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Obsolete:UnsubscribedSet:result:" + result.GetStatus());
           
            this._error = new ErrorData();
            this._error.Status = apiResponse.Item1;
            this._error.Details = _mapper.Map<ErrorDetailsData>(result.GetResponse()); 
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Obsolete:UnsubscribedSet:END");

            return null!;
        }
    }

    public async Task<UnsubscribedData> UnsubscribedCheck(string emailAddress)
    {
        _error = null;
        if(_apiConnection.IsLoggingEnabled())
            _logger.Information("Obsolete:UnsubscribedCheck:emailAddress[" + emailAddress +"]");
        
        var apiResponse = await _apiConnection.SendMessageAsync("unsubscribed/check.json", EmailAddressData.CreateNew(emailAddress));
        if (!apiResponse.Item1.ToLower().Contains("error") && !apiResponse.Item2.ToLower().Contains("error") && !apiResponse.Item1.ToLower().Contains("cancelled"))
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
            var result = OperationResult<ErrorDetailsData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Obsolete:UnsubscribedCheck:result:" + result.GetStatus());
           
            this._error = new ErrorData();
            this._error.Status = apiResponse.Item1;
            if (!this._error.Status.Contains("timeout"))
                this._error.Details = _mapper.Map<ErrorDetailsData>(result.GetResponse());
            else
                this._error.Details = ErrorDetailsData.CreateNew("TIMEOUT", apiResponse.Item1, 0);

            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Obsolete:UnsubscribedCheck:END");

            return null!;
        }
    }

    public async Task<UnsubscribedList> UnsubscribedList(string emailAddress)
    {
        _error = null;
        if(_apiConnection.IsLoggingEnabled())
            _logger.Information("Obsolete:UnsubscribedList:emailAddress[" + emailAddress +"]");
        
        var apiResponse = await _apiConnection.SendMessageAsync("unsubscribed/list.json", EmailAddressData.CreateNew(emailAddress));
        if (!apiResponse.Item1.ToLower().Contains("error") && !apiResponse.Item2.ToLower().Contains("error") && !apiResponse.Item1.ToLower().Contains("cancelled"))
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
            var result = OperationResult<ErrorDetailsData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Obsolete:UnsubscribedList:result:" + result.GetStatus());
           
            this._error = new ErrorData();
            this._error.Status = apiResponse.Item1;
            if (!this._error.Status.Contains("timeout"))
                this._error.Details = _mapper.Map<ErrorDetailsData>(result.GetResponse());
            else
                this._error.Details = ErrorDetailsData.CreateNew("TIMEOUT", apiResponse.Item1, 0);

            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Obsolete:UnsubscribedList:END");

            return null!;
        }
    }
    
    public ErrorData? GetError() => _error;
}