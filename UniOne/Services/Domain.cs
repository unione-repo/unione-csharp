using AutoMapper;
using UniOne.Models;

namespace UniOne;

public class Domain
{
    private readonly IApiConnection _apiConnection;
    private readonly IMapper _mapper;

    public Domain(IApiConnection apiConnection, IMapper mapper)
    {
        _apiConnection = apiConnection;
        _mapper = mapper;
    }
    
    public DomainData GetDNSRecords(string domain)
    {
        string response = "";
        var apiResponse = _apiConnection.SendMessage("domain/get-dns-records.json", DomainData.CreateNew(domain), out response);
        var result = OperationResult.CreateNew(response,apiResponse);

        var mappedResult = _mapper.Map<DomainData>(result);
        
        return mappedResult;
    }
    
    public DomainData ValidateVerificationRecord(string domain)
    {
        string response = "";
        var apiResponse = _apiConnection.SendMessage("domain/validate-verification-record.json", DomainData.CreateNew(domain), out response);
        var result = OperationResult.CreateNew(response,apiResponse);

        var mappedResult = _mapper.Map<DomainData>(result);
        
        return mappedResult;
    }
    
    public DomainData ValidateDkim(string domain)
    {
        string response = "";
        var apiResponse = _apiConnection.SendMessage("domain/validate-dkim.json", DomainData.CreateNew(domain), out response);
        var result = OperationResult.CreateNew(response,apiResponse);

        var mappedResult = _mapper.Map<DomainData>(result);
        
        return mappedResult;
    }
    
    public DomainData List(string domain, int limit = 50,int offset = 0 )
    {
        string response = "";
        var apiResponse = _apiConnection.SendMessage("domain/list.json", DomainData.CreateNew(domain,limit,offset), out response);
        var result = OperationResult.CreateNew(response,apiResponse);

        var mappedResult = _mapper.Map<DomainData>(result);
        
        return mappedResult;
    }
}