using System.Text.Json.Serialization;

namespace UniOne.Models;

public class UnsubscribedData
{
    /// <summary>
    /// Email address
    /// </summary>
    [JsonPropertyName("address")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? EmailAddress { get; set; }
    
    /// <summary>
    /// Date and time when a recipient unsubscribed, in UTC timezone and “YYYY-MM-DD hh:mm:ss” format.
    /// </summary>
    [JsonPropertyName("unsubscribed_on")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime UnsubscribedOn { get; set; }
    
    /// <summary>
    /// true if unsubscribed, false if not.
    /// </summary>
    [JsonPropertyName("is_unsubscribed")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool IsUnsubscribed { get; set; }
    
    /// <summary>
    /// Human-readable error message in English.
    /// </summary>
    [JsonPropertyName("message")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Message { get; set; }
    
    private UnsubscribedData(){}

    private UnsubscribedData(string emailAddress, DateTime unsubscribedOn, bool isUnsubscribed, string message)
    {
        EmailAddress = emailAddress;
        UnsubscribedOn = unsubscribedOn;
        IsUnsubscribed = isUnsubscribed;
        Message = message;
    }

    public static UnsubscribedData CreateNew(string emailAddress, DateTime unsubscribedOn, bool isUnsubscribed, string message)
    {
        return new UnsubscribedData(emailAddress, unsubscribedOn, isUnsubscribed, message);
    }
}

public class UnsubscribedList
{
    [JsonPropertyName("status")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? status { get; set; }
    
    [JsonPropertyName("unsubscribed")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<UnsubscribedData>? Unsubscribed { get; set; }
}