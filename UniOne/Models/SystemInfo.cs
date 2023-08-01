namespace UniOne.Models;

public class SystemInfo
{
    private string _status { get; set; }
    private string _userId { get; set; }
    private string _emailAddress { get; set; }
    private string? _projectId { get; set; }
    private string? _projectName { get; set; }
    private Accounting? _accounting { get; set; }

    public SystemInfo(){}

    private SystemInfo(string status, string userId, string emailAddress, string? projectId, string? projectName,
        Accounting? accounting)
    {
        _status = status;
        _userId = userId;
        _emailAddress = emailAddress;
        _projectId = projectId;
        _projectName = projectName;
        _accounting = accounting;
    }

    public static SystemInfo CreateNew(string status, string userId, string emailAddress, string? projectId,
        string? projectName, Accounting? accounting)
    {
        return new SystemInfo(status, userId, emailAddress, projectId, projectName, accounting);
    }
}