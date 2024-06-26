﻿using AutoMapper;
using Newtonsoft.Json;
using Serilog;
using UniOne.Models;

namespace UniOne;

public class System
{
    private readonly IApiConnection _apiConnection;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private ErrorData? _error;

    public System(IApiConnection apiConnection, IMapper mapper,ILogger logger)
    {
        _apiConnection = apiConnection;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<SystemInfoData> SystemInfo()
    {
        _error = null;
        if(_apiConnection.IsLoggingEnabled())
            _logger.Information("System:SystemInfo");
        
        var apiResponse = await _apiConnection.SendMessageAsync("system/info.json", "{ }");

        if (!apiResponse.Item1.ToLower().Contains("error") && !apiResponse.Item2.ToLower().Contains("error") && !apiResponse.Item1.ToLower().Contains("cancelled"))
        {
            var result = OperationResult<SystemInfoData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("System:SystemInfo:result:" + result.GetStatus());
    
            var mappedResult = _mapper.Map<SystemInfoData>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("System:SystemInfo:END");

            return mappedResult;
        }
        else
        {
            var result = OperationResult<ErrorDetailsData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("System:SystemInfo:result:" + result.GetStatus());
           
            this._error = new ErrorData();
            this._error.Status = apiResponse.Item1;
            if (!this._error.Status.Contains("timeout"))
                this._error.Details = _mapper.Map<ErrorDetailsData>(result.GetResponse());
            else
                this._error.Details = ErrorDetailsData.CreateNew("TIMEOUT", apiResponse.Item1, 0);

            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("System:SystemInfo:END");

            return null!;
        }
    }
    
    public ErrorData? GetError() => _error;
}