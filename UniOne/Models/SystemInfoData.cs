namespace UniOne.Models;

public class SystemInfoData
{
    private string _status { get; set; }
    private string _userId { get; set; }
    private string _emailAddress { get; set; }
    private string? _projectId { get; set; }
    private string? _projectName { get; set; }
    private AccountingData? _accounting { get; set; }

    public SystemInfoData(){}

    private SystemInfoData(string status, string userId, string emailAddress, string? projectId, string? projectName,
        AccountingData? accounting)
    {
        _status = status;
        _userId = userId;
        _emailAddress = emailAddress;
        _projectId = projectId;
        _projectName = projectName;
        _accounting = accounting;
    }

    public static SystemInfoData CreateNew(string status, string userId, string emailAddress, string? projectId,
        string? projectName, AccountingData? accounting)
    {
        return new SystemInfoData(status, userId, emailAddress, projectId, projectName, accounting);
    }
}