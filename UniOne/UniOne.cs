using Microsoft.Extensions.Configuration;

namespace UniOne;

public class UniOne : IUniOne
{
    
    private static string? _x_api_key = "";
    private static string? _api_key = "";
    private static string? _server = "";
   
    public static void Configure(IConfiguration configuration)
    {
        _x_api_key = configuration["X-API-KEY"]?.ToString();
        _api_key = configuration["api_key"]?.ToString();
        _server = configuration["server"]?.ToString();
    }
    
}