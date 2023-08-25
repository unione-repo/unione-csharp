﻿using Newtonsoft.Json;

namespace UniOne.Models;

public class SystemInfoData
{
    /// <summary>
    /// “success” string
    /// </summary>
    [JsonProperty("status")]
    public string Status { get; set; }
    /// <summary>
    /// Unique user identifier.
    /// </summary>
    [JsonProperty("user_id")]
    public int UserId { get; set; }
    /// <summary>
    /// Email of the user.
    /// </summary>
    [JsonProperty("email")]
    public string EmailAddress { get; set; }
    /// <summary>
    /// Unqiue project identifier, ASCII string up to 36 characters long. Present only if the API key used for request is the project API key
    /// </summary>
    [JsonProperty("project_id")]
    public string? ProjectId { get; set; }
    /// <summary>
    /// Project name, unique for user account. Present only if the API key used for request is the project API key.
    /// </summary>
    [JsonProperty("project_name")]
    public string? ProjectName { get; set; }
    [JsonProperty("accounting")]
    public AccountingData? Accounting { get; set; }

    public SystemInfoData(){}

    private SystemInfoData(string status, int userId, string emailAddress, string? projectId, string? projectName,
        AccountingData? accounting)
    {
        Status = status;
        UserId = userId;
        EmailAddress = emailAddress;
        ProjectId = projectId;
        ProjectName = projectName;
        Accounting = accounting;
    }

    public static SystemInfoData CreateNew(string status, int userId, string email, string projectId, string projectName, DateTime period_start, DateTime period_end, int emails_included, int email_sent)
    {
        var accounting = AccountingData.CreateNew(period_start, period_end, emails_included, email_sent);
        
        return new SystemInfoData(status, userId,email,projectId,projectName,accounting);
    }
}