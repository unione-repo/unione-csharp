using AutoMapper;

namespace UniOne;

public class Tag
{
    private readonly IApiConnection _apiConnection;
    private readonly IMapper _mapper;

    public Tag(IApiConnection apiConnection, IMapper mapper)
    {
        _apiConnection = apiConnection;
        _mapper = mapper;
    }
    
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