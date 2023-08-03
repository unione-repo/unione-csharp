using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace UniOne;

public class ApiConnection: IApiConnection
{
    private readonly IApiConfiguration _apiConfiguration;
   
    public ApiConnection(IApiConfiguration apiConfiguration)
    {
        _apiConfiguration = apiConfiguration;
    }
    

    public string SendMessage(string command, object request, out string apiResponse)
    {
        var client = new HttpClient();

        client.BaseAddress = new Uri(_apiConfiguration.GetApiUrl());
        client.DefaultRequestHeaders.Add("X-API-KEY",_apiConfiguration.GetApiKey());
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        string requestBody = JsonSerializer.Serialize(request);

        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        var response = client.PostAsync(command, content).Result;
        var responseBody = response.Content.ReadAsStringAsync().Result;

        apiResponse = response.StatusCode.ToString();
       
        return responseBody;
    }
}