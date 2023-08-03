namespace UniOne.Models;

public class DomainData
{
    private string _domain { get; set; }
    private int _limit { get; set; }
    private int _offset { get; set; }
    private string _status { get; set; }
    private string _verification_record { get; set; }
    private string _dkim { get; set; }

    public string Domain => _domain;
    public int Limit => _limit;
    public int Offset => _offset;
    public string Status => _status;
    public string VerificationRecord => _verification_record;
    public string DKIM => _dkim;

    private DomainData()
    {
    }

    private DomainData(string domain, int limit = 50, int offset = 0)
    {
        _domain = domain;
        _limit = limit;
        _offset = offset;
    }

    public static DomainData CreateNew(string domain, int limit = 50, int offset = 0)
    {
        return new DomainData(domain, limit, offset);
    }
}

public class VerificationRecord
{
    private string _value { get; set; }
    private string _status { get; set; }

    public string Value => _value;
    public string Status => _status;

    private VerificationRecord(){}

    private VerificationRecord(string value, string status)
    {
        _value = value;
        _status = status;
    }

    public static VerificationRecord CreateNew(string value, string status)
    {
        return new VerificationRecord(value, status);
    }
}

public class DKIM
{
    private string _key { get; set; }
    private string _status { get; set; }

    public string Key => _key;
    public string Status => _status;
    
    private DKIM(){}

    private DKIM(string key, string status)
    {
        _key = key;
        _status = status;
    }

    public static DKIM CreateNew(string key, string status)
    {
        return new DKIM(key, status);
    }
}