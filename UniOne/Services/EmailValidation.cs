using AutoMapper;

namespace UniOne;

public class EmailValidation
{
    private readonly IApiConnection _apiConnection;
    private readonly IMapper _mapper;

    public EmailValidation(IApiConnection apiConnection, IMapper mapper)
    {
        _apiConnection = apiConnection;
        _mapper = mapper;
    }
    // public IOperationResult ValidationSingle()
    // {
    //     var result = new OperationResult();
    //
    //     return result;
    // }
}