using AutoMapper;
using Microsoft.Extensions.Configuration;
using Serilog;


namespace UniOne;

public class UniOne : IUniOne
{
    ILogger _logger;
    IMapper _mapper;
    IApiConfiguration _apiConfiguration;
    IApiConnection _apiConnection;
    
    private string _x_api_key = "";
    private string _server = "";
    private int _serverTimeout = 0;
    private bool _enableLogging = false;
    private string _apiUrl = "";
    private string _apiVersion = "";
    
    private readonly Domain _domain;
    private readonly Email _email;
    private readonly EmailValidation _emailValidation;
    private readonly EventDump _eventDump;
    private readonly Obsolete _obsolete;
    private readonly Project _project;
    private readonly Suppression _suppression;
    private readonly System _system;
    private readonly Tag _tag;
    private readonly Template _template;
    private readonly Webhook _webhook;
    private readonly Generic _generic;

    public string X_Api_Key => _x_api_key;
    public string Server => _server;
    public int ServerTimeout => _serverTimeout;
    public bool EnableLogging => _enableLogging;
    public string? ApiUrl => _apiUrl;
    private string? ApiVersion => _apiVersion;

    public Domain Domain => _domain;
    public Email Email => _email;
    public EmailValidation EmailValidation => _emailValidation;
    public EventDump EventDump => _eventDump;
    public Obsolete Obsolete => _obsolete;
    public Project Project => _project;
    public Suppression Suppression => _suppression;
    public System System => _system;
    public Tag Tag => _tag;
    public Template Template => _template;
    public Webhook Webhook => _webhook;
    public Generic Generic => _generic;
    
    
    public UniOne(IConfiguration configuration)
    {
        var config = configuration.GetSection("UniOne");
        
        _x_api_key = config["X-API-KEY"]?.ToString() ?? string.Empty;
        _server = config["ServerAddress"]?.ToString() ?? string.Empty;
        _serverTimeout = int.Parse(config["ServerTimeout"]?.ToString() ?? "5000");
        _enableLogging = bool.Parse(config["EnableLogging"]?.ToString( )?? "false");
        _apiUrl = config["ApiUrl"]?.ToString() ?? "en/transactional/api/";
        _apiVersion = config["ApiVersion"]?.ToString() ?? "v1";
        
        _logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("UniOne-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
        
        var mapperConfiguration = new MapperConfiguration(cfg => {});

        _mapper = mapperConfiguration.CreateMapper();

        _apiConfiguration =
            ApiConfiguration.CreateNew(_server, _apiUrl, _apiVersion, _x_api_key, _enableLogging, _serverTimeout);

        _apiConnection = new ApiConnection(_apiConfiguration);
        

        _domain = new Domain(_apiConnection, _mapper, _logger);
        _email = new Email(_apiConnection, _mapper, _logger);
        _emailValidation = new EmailValidation(_apiConnection, _mapper, _logger);
        _eventDump = new EventDump(_apiConnection, _mapper, _logger);
        _obsolete = new Obsolete(_apiConnection, _mapper, _logger);
        _project = new Project(_apiConnection, _mapper, _logger);
        _suppression = new Suppression(_apiConnection, _mapper, _logger);
        _system = new System(_apiConnection, _mapper, _logger);
        _tag = new Tag(_apiConnection, _mapper, _logger);
        _template = new Template(_apiConnection, _mapper, _logger);
        _webhook = new Webhook(_apiConnection, _mapper, _logger);
        _generic = new Generic(_apiConnection, _mapper, _logger);
    }
}