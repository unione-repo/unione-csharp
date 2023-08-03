using UniOne.Models;
using System.Collections.Generic;
using AutoMapper;

namespace UniOne;

public class Obsolete
{
    private readonly IApiConnection _apiConnection;
    private readonly IMapper _mapper;

    public Obsolete(IApiConnection apiConnection, IMapper mapper)
    {
        _apiConnection = apiConnection;
        _mapper = mapper;
    }
    public UnsubscibedData UnsubscribedSet(string emailAddress)
    {
        string response = "";
        var apiResponse = _apiConnection.SendMessage("unsubscribed/set.json", EmailAddressData.CreateNew(emailAddress), out response);
        var result = OperationResult.CreateNew(response,apiResponse);

        var mappedResult = _mapper.Map<UnsubscibedData>(result);
        
        return mappedResult;
    }

    public UnsubscibedData UnsubscribedCheck(string emailAddress)
    {
        string response = "";
        var apiResponse = _apiConnection.SendMessage("unsubscribed/check.json", EmailAddressData.CreateNew(emailAddress), out response);
        var result = OperationResult.CreateNew(response,apiResponse);

        var mappedResult = _mapper.Map<UnsubscibedData>(result);
        
        return mappedResult;
    }

    public IEnumerable<UnsubscibedData> UnsubscribedList(string emailAddress)
    {
        string response = "";
        var apiResponse = _apiConnection.SendMessage("unsubscribed/list.json", EmailAddressData.CreateNew(emailAddress), out response);
        var result = OperationResult.CreateNew(response,apiResponse);

        return new List<UnsubscibedData>();
    }
}