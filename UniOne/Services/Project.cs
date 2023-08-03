using AutoMapper;

namespace UniOne;

public class Project
{
    private readonly IApiConnection _apiConnection;
    private readonly IMapper _mapper;

    public Project(IApiConnection apiConnection, IMapper mapper)
    {
        _apiConnection = apiConnection;
        _mapper = mapper;
    }
    // public IOperationResult Create()
    // {
    //     var result = new OperationResult();
    //
    //     return result;
    // }
    //
    // public IOperationResult Update()
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
    // public IOperationResult Delete()
    // {
    //     var result = new OperationResult();
    //
    //     return result;
    // }
}