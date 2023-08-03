using AutoMapper;
using UniOne.Models;

namespace UniOne;

public class System
{
    private readonly IApiConnection _apiConnection;
    private readonly IMapper _mapper;

    public System(IApiConnection apiConnection, IMapper mapper)
    {
        _apiConnection = apiConnection;
        _mapper = mapper;
    }
    // public IOperationResult<SystemInfo> SystemInfo()
    // {
    //     var result = new OperationResult<SystemInfo>();
    //
    //     return result;
    // }
}