using System.Text.Json.Serialization;

namespace UniOne.Models;

public class EmailSubscribeData
{
    /// <summary>
    /// Sender’s email.
    /// </summary>
    [JsonPropertyName("from_email")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FromEmail { get; set; }
    
    /// <summary>
    /// Sender’s name.
    /// </summary>
    [JsonPropertyName("from_name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FromName { get; set; }
    
    /// <summary>
    /// Recipient’s email.
    /// </summary>
    [JsonPropertyName("to_email")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ToEmail { get; set; }
    
    private EmailSubscribeData(){}

    private EmailSubscribeData(string from, string name, string to)
    {
        FromEmail = from;
        FromName = name;
        ToEmail = to;
    }

    public static EmailSubscribeData CreateNew(string from, string name, string to)
    {
        return new EmailSubscribeData(from, name, to);
    }
}