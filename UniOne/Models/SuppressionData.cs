﻿using System.Text.Json.Serialization;

namespace UniOne.Models;

public class SuppressionData
{
    /// <summary>
    /// “success” string
    /// </summary>
    [JsonPropertyName("status")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Status { get; set; }
    
    /// <summary>
    /// The email for which suppression details were requested.
    /// </summary>
    [JsonPropertyName("cause")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Email { get; set; }
    
    /// <summary>
    /// The parameter indicates from which position the selection is to be started. Must be empty or omitted for the first data chunk. In order to get subsequent chunks, you must set the “cursor” parameter in your request, using the value received in response to the previous request.
    /// </summary>
    [JsonPropertyName("cursor")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Cursor { get; set; }
    
    /// <summary>
    /// Array of suppression objects.
    /// </summary>
    [JsonPropertyName("suppressions")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<SuppressionsData> Suppressions { get; set; }

    public SuppressionData(){}
}

public class SuppressionsData
{
    /// <summary>
    /// Unqiue project identifier, ASCII string up to 36 characters long.
    /// </summary>
    [JsonPropertyName("project_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ProjectId { get; set; }
    
    /// <summary>
    /// Value from SuppressionCause class
    /// </summary>
    [JsonPropertyName("cause")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Cause { get; set; }
    
    /// <summary>
    /// Source of email being suppressed. One of:
    /// user - suppressed by user with suppression/set;
    /// system - sending to the email is prohibited by system, for example due to multiple hard bounces;
    /// subscriber - the recipient reported spam or unsubscribed in the previous emails.
    /// </summary>
    [JsonPropertyName("source")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Source { get; set; }
    
    /// <summary>
    /// Is it possible to delete this suppression by calling suppression/delete method.
    /// </summary>
    [JsonPropertyName("is_deletable")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool Is_deletable { get; set; }
    
    /// <summary>
    /// When suppression was created, in UTC timezone in “YYYY-MM-DD hh:mm:ss” format.
    /// </summary>
    [JsonPropertyName("created")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime Created { get; set; }
    
    /// <summary>
    /// Limits the number of records to be returned at one time, default is 50.
    /// </summary>
    [JsonPropertyName("limit")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int Limit { get; set; }

    public SuppressionsData() { }
}

public class SuppressionInputData
{
    /// <summary>
    /// Email to get suppression details for.
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// value from SuppressionCause class
    /// </summary>
    public string Cause { get; set; }
    
    /// <summary>
    /// When suppression was created, in UTC timezone in “YYYY-MM-DD hh:mm:ss” format.
    /// </summary>
    public DateTime Created { get; set; }
    
    /// <summary>
    /// If a user has projects functionality enabled, he/she can pass all_projects=true to search in all projects’ data.
    /// </summary>
    public bool AllProjects { get; set; }
    
    public SuppressionInputData(){}

    private SuppressionInputData(string email, string cause = null, DateTime created = new DateTime(), bool allProjects = false)
    {
        Email = email;
        Cause = cause;
        Created = created;
        AllProjects = allProjects;
    }

    public static SuppressionInputData CreateNew(string email, string cause = null, DateTime created = new DateTime(), bool allProjects = false)
    {
        return new SuppressionInputData(email, cause, created, allProjects);
    }
}

public class SuppressionCause
{
    /// <summary>
    /// Email is unsubscribed;
    /// </summary>
    public const string Unsubscribed = "unsubscribed";
    
    /// <summary>
    /// the email address is unavailable. This means that over the next three days sending to this address will return an error. Email may be temporarily unavailable due to several reasons, e.g.:
    /// a previous email has been rejected by the recipient’s server for spam;
    /// the recipient’s mailbox is full or is not used;
    /// recipient’s domain does not accept mail;
    /// sending server was rejected due to blacklisting;
    /// </summary>
    public const string TemporaryUnavailable = "temporary_unavailable";
    
    /// <summary>
    /// The email address is permanently unavailable due to multiple hard bounces;
    /// </summary>
    public const string PermanentUnavailable = "permanent_unavailable";
    
    /// <summary>
    /// The recipient reported spam in the previous emails;
    /// </summary>
    public const string Complained = "complained";
    
    /// <summary>
    ///  sending to the email is prohibited by administration of UniOne.
    /// </summary>
    public const string Blocked = "blocked";
}

public class SuppressionListFilters
{
    /// <summary>
    /// Value from SuppressionCause class
    /// </summary>
    [JsonPropertyName("cause")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Cause { get; set; }
    
    /// <summary>
    /// Source of email being suppressed. One of:
    ///     user - suppressed by user with suppression/set;
    ///     system - sending to the email is prohibited by system, for example due to multiple hard bounces;
    ////    subscriber - the recipient reported spam or unsubscribed in the previous emails.
    /// </summary>
    [JsonPropertyName("source")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Source { get; set; }
    
    /// <summary>
    /// Date in the format YYYY-MM-DD hh:mm:ss to get suppression list from the “start_time” to the present day. Ignored if “cursor” is not empty.
    /// </summary>
    [JsonPropertyName("start_time")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? StartTime { get; set; }
    
    /// <summary>
    /// The parameter indicates from which position the selection is to be started. Must be empty or omitted for the first data chunk.
    /// In order to get subsequent chunks, you must set the “cursor” parameter in your request, using the value received in response to the previous request.
    /// </summary>
    [JsonPropertyName("cursor")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Cursor { get; set; }
    
    /// <summary>
    /// Limits the number of records to be returned at one time, default is 50.
    /// </summary>
    [JsonPropertyName("limit")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int Limit { get; set; }


    public SuppressionListFilters(string cause, string source, DateTime? startTime, string cursor, int limit = 50)
    {
        Cause = cause;
        Source = source;
        StartTime = startTime;
        Cursor = cursor;
        Limit = limit;
    }
}