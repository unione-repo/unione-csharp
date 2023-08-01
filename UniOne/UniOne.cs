using Microsoft.Extensions.Configuration;

namespace UniOne;

public class UniOne : IUniOne
{
    
    private static string? _x_api_key = "";
    private static string? _api_key = "";
    private static string? _server = "";
    private readonly Email _email = new Email();
    private readonly EmailValidation _emailValidation = new EmailValidation();
    private readonly Template _template = new Template();
    private readonly Webhook _webhook = new Webhook();
    private readonly Suppression _suppression = new Suppression();
    private readonly Domain _domain = new Domain();
    private readonly EventDump _eventDump = new EventDump();
    private readonly Tag _tag = new Tag();
    private readonly Project _project = new Project();
    private readonly System _system = new System();
    private readonly Obsolete _obsolete = new Obsolete();


    public static void Configure(IConfiguration configuration)
    {
        _x_api_key = configuration["X-API-KEY"]?.ToString();
        _api_key = configuration["api_key"]?.ToString();
        _server = configuration["server"]?.ToString();
    }
    
}