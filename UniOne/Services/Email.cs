using AutoMapper;

namespace UniOne;

public class Email
{
    private readonly IApiConnection _apiConnection;
    private readonly IMapper _mapper;

    public Email(IApiConnection apiConnection, IMapper mapper)
    {
        _apiConnection = apiConnection;
        _mapper = mapper;
    }
    // public IOperationResult Send()
    // {
    //     var result = new OperationResult();
    //
    //     return result;
    // }
    //
    // public IOperationResult Subscribe()
    // {
    //     var result = new OperationResult();
    //
    //     return result;
    // }
}