using AutoMapper;

namespace UniOne;

public class Template
{
    private readonly IApiConnection _apiConnection;
    private readonly IMapper _mapper;

    public Template(IApiConnection apiConnection, IMapper mapper)
    {
        _apiConnection = apiConnection;
        _mapper = mapper;
    }
    
    // public IOperationResult Set()
    // {
    //     var result = new OperationResult();
    //
    //     return result;
    // }
    //
    // public IOperationResult Get()
    // {
    //     var result = new OperationResult();
    //
    //     return result;
    // }
    //
    // public IOperationResult List()
    // {
    //     var result = new OperationResult();
    //
    //     return result;
    // }
    //
    // public IOperationResult Detele()
    // {
    //     var result = new OperationResult();
    //
    //     return result;
    // }
}