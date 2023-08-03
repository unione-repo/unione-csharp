﻿using UniOne.Exceptions;

namespace UniOne;

public class ApiConfiguration : IApiConfiguration
{
    private string _serverAddress { get; set; }
    private string _apiUrl { get; set; }
    private string _apiVersion { get; set; }
    private string _apiKey { get; set; }

    public string ApiUrl => _apiUrl;
    public string ApiVersion => _apiVersion;
    public string ApiKey => _apiKey;
    public string ServerAddress => _serverAddress;
    
    private ApiConfiguration(){}

    private ApiConfiguration(string serverAddress, string apiUrl, string apiVersion, string apiKey)
    {
        _serverAddress = serverAddress;
        _apiUrl = apiUrl;
        _apiVersion = apiVersion;
        _apiKey = apiKey;
    }

    public static ApiConfiguration CreateNew(string serverAddress, string apiUrl, string apiVersion, string apiKey)
    {
        if (string.IsNullOrEmpty(serverAddress) || (string.IsNullOrEmpty(apiUrl) && !apiUrl.Contains(@"/")) || (string.IsNullOrEmpty(apiVersion) && !apiUrl.Contains(@"/") ) || string.IsNullOrEmpty(apiKey))
            throw new EmptyApiConfigurationException();

        if (!serverAddress.EndsWith(@"/"))
            serverAddress = serverAddress + @"/";
        
        if (!apiUrl.EndsWith(@"/"))
            apiUrl = apiUrl + @"/";

        if (!apiVersion.EndsWith(@"/"))
            apiVersion = apiVersion + @"/";

        return new ApiConfiguration(serverAddress, apiUrl, apiVersion, apiKey);
    }

    public string GetApiUrl() => _serverAddress + _apiUrl + _apiVersion;
    public string GetApiKey() => _apiKey;
}