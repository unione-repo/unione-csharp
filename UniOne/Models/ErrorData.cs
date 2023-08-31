using AutoMapper;
using AutoMapper.Configuration.Annotations;

namespace UniOne.Models;

public class ErrorData
{
    /// <summary>
    /// “error” string
    /// </summary>
    [SourceMember("status")]
    public string Status { get; set; }
    /// <summary>
    /// Human-readable error message in English.
    /// </summary>
    [SourceMember("message")]
    public string Message { get; set; }
    /// <summary>
    /// API Error code - https://docs.unione.io/en/web-api-ref#api-errors
    /// </summary>
    [SourceMember("code")]
    public int Code { get; set; }

    public ErrorData(){}

    private ErrorData(string status, string message, int code)
    {
        Status = status;
        Message = message;
        Code = code;
    }

    public static ErrorData CreateNew(string status, string message, int errorCode)
    {
        return new ErrorData(status, message, errorCode);
    }
}