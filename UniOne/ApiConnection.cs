﻿using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace UniOne;

public class ApiConnection: IApiConnection
{
    private readonly IApiConfiguration _apiConfiguration;
    private readonly bool _enableLogging; 
   
    public ApiConnection(IApiConfiguration apiConfiguration)
    {
        _apiConfiguration = apiConfiguration;
        _enableLogging = apiConfiguration.IsLoggingEnabled();
    }
    

    public async Task<(string, string)> SendMessageAsync(string command, object request)
    {
        string apiResponse = string.Empty;
        string responseBody = string.Empty;
    
        using (var cancellationTokenSource = new CancellationTokenSource(_apiConfiguration.GetTimeout()))
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(_apiConfiguration.GetApiUrl());
            client.DefaultRequestHeaders.Add("X-API-KEY", _apiConfiguration.GetApiKey());
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string requestBody = requestBody = !request.ToString().Contains("{") ? JsonSerializer.Serialize(request) : request.ToString();
            
            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(command, content, cancellationTokenSource.Token);

                if (cancellationTokenSource.IsCancellationRequested)
                {
                    apiResponse = "Request cancelled due to timeout.";
                }
                else
                {
                    apiResponse = response.StatusCode.ToString();
                    responseBody = await response.Content.ReadAsStringAsync();
                }
            }
            catch (TaskCanceledException)
            {
                apiResponse = "Request cancelled due to timeout.";
            }

            return (apiResponse, responseBody);
        }
    }

    public bool IsLoggingEnabled() => _enableLogging;
}