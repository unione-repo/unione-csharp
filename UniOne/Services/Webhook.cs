﻿using AutoMapper;
using Newtonsoft.Json;
using Serilog;
using UniOne.Models;

namespace UniOne;

public class Webhook
{
    private readonly IApiConnection _apiConnection;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private ErrorData _error;

    public Webhook(IApiConnection apiConnection, IMapper mapper, ILogger logger)
    {
        _apiConnection = apiConnection;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<IOperationResult<string>> Set(WebhookData webhookData)
    {
        _error = null;
        if(_apiConnection.IsLoggingEnabled())
            _logger.Information("Webhook:Set");

        string response = "";
        var apiResponse = await _apiConnection.SendMessageAsync("webhook/set.json", webhookData);
        if (!apiResponse.Item1.ToLower().Contains("error"))
        {
            var result = OperationResult<string>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Webhook:Set:result:" + result.GetStatus());
            
            var mappedResult = _mapper.Map<string>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Webhook:Set:END");

            return mappedResult;
        }
        else
        {
            var result = OperationResult<ErrorData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Webhook:Set:result:" + result.GetStatus());
           
            _error = _mapper.Map<ErrorData>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Webhook:Set:END");

            return null;
        }
    }

    public async Task<WebhookData> Get(string url)
    {
        _error = null;
        if(_apiConnection.IsLoggingEnabled())
            _logger.Information("Webhook:Get:url[" + url +"]");

        string response = "";
        var apiResponse = await _apiConnection.SendMessageAsync("webhook/get.json", "{ \"url:\" \""+ url + " \"  }");
        if (!apiResponse.Item1.ToLower().Contains("error"))
        {
            var result = OperationResult<WebhookData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Webhook:Get:result:" + result.GetStatus());
            
            var mappedResult = _mapper.Map<WebhookData>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Webhook:Get:END");

            return mappedResult;
        }
        else
        {
            var result = OperationResult<ErrorData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Webhook:Get:result:" + result.GetStatus());
           
            _error = _mapper.Map<ErrorData>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Webhook:Get:END");

            return null;
        }
    }
    
    public async Task<WebhookData> List(int limit = 50, int offset = 0)
    {
        _error = null;
        if(_apiConnection.IsLoggingEnabled())
            _logger.Information("Webhook:List:limit["+limit+"]:offset["+offset+"]");

        string response = "";
        var apiResponse = await _apiConnection.SendMessageAsync("webhook/list.json", InputData.CreateNew(null,limit,offset));
        if (!apiResponse.Item1.ToLower().Contains("error"))
        {
            var result = OperationResult<WebhookData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Webhook:List:result:" + result.GetStatus());
            
            var mappedResult = _mapper.Map<WebhookData>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Webhook:List:END");

            return mappedResult;
        }
        else
        {
            var result = OperationResult<ErrorData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Webhook:List:result:" + result.GetStatus());
           
            _error = _mapper.Map<ErrorData>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Webhook:List:END");

            return null;
        }
    }
    
    public async Task<IOperationResult<string>> Delete(string url)
    {
        _error = null;
        if(_apiConnection.IsLoggingEnabled())
            _logger.Information("Webhook:Delete:Detele[" + url +"]");

        string response = "";
        var apiResponse = await _apiConnection.SendMessageAsync("webhook/delete.json", "{ \"url:\" \""+ url + " \"  }");
        if (!apiResponse.Item1.ToLower().Contains("error"))
        {
            var result = OperationResult<string>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Webhook:Delete:result:" + result.GetStatus());
            
            var mappedResult = _mapper.Map<string>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Webhook:Delete:END");

            return mappedResult;
        }
        else
        {
            var result = OperationResult<ErrorData>.CreateNew(apiResponse.Item1, apiResponse.Item2);
            
            if(_apiConnection.IsLoggingEnabled())
                _logger.Information("Webhook:Delete:result:" + result.GetStatus());
           
            _error = _mapper.Map<ErrorData>(result.GetResponse());
            
            if (_apiConnection.IsLoggingEnabled())
                _logger.Information("Webhook:Delete:END");

            return null;
        }
    }
    
    public ErrorData GetError() => _error;
}