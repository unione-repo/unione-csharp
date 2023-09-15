using System.Text.Json.Serialization;
using AutoMapper.Configuration.Annotations;

namespace UniOne.Models;

public class ErrorData
{
    public string Status { get; set; }
    public ErrorDetailsData Details { get; set; }
}

public class ErrorDetailsData
{
    /// <summary>
    /// “error” string
    /// </summary>
    [SourceMember("status")]
    [JsonPropertyName("status")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Status { get; set; }
    
    /// <summary>
    /// Human-readable error message in English.
    /// </summary>
    [SourceMember("message")]
    [JsonPropertyName("message")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Message { get; set; }
    
    /// <summary>
    /// API Error code - https://docs.unione.io/en/web-api-ref#api-errors
    /// </summary>
    [SourceMember("code")]
    [JsonPropertyName("code")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int Code { get; set; }
    
    public string CodeDescription { get; set; }

    public ErrorDetailsData(){}

    private ErrorDetailsData(string status, string message, int code)
    {
        Status = status;
        Message = message;
        Code = code;
    }

    public static ErrorDetailsData CreateNew(string status, string message, int errorCode)
    {
        return new ErrorDetailsData(status, message, errorCode);
    }
}