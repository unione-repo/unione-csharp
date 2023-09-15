﻿using System.Text.Json.Serialization;

namespace UniOne.Models;

public class EmailValidationData
{
    /// <summary>
    /// “success” string
    /// </summary>
    [JsonPropertyName("status")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Status { get; set; }
    
    /// <summary>
    /// Email address to be checked.
    /// </summary>
    [JsonPropertyName("email")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Email { get; set; }
    
    /// <summary>
    /// Possible statuses:
    ///  “valid” - the address is valid,
    ///  “invalid” - the address is invalid,
    ///  “suspicious” - the address looks suspicious,
    ///  “unknown” - could not perform validation, the domain’s mail server has not responded within the time limit.
    /// </summary>
    [JsonPropertyName("result")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Result { get; set; }
    
    /// <summary>
    /// Possible statuses:
    ///   “no_mx_record” - no MX record found for the target domain,
    ///   “syntax_error” - the address syntax is invalid,
    ///   “possible_typo” - the address is likely to have a typo,
    ///   “mailbox_not_found” - the address does not exist,
    ///   “global_suppression” - the address has been marked as unreachable due to multiple previous delivery errors,
    ///   “disposable” - this is a disposable one-time email address which is usually valid for a few minutes only,
    ///   “role” - the address is not likely to belong to an actual person, but rather to a certain business staff role,
    ///   “abuse” - the address is known to be a source of a large number of complaints, sometimes issued automatically,
    ///   “spamtrap” - this email is a spam trap, it is published openly but never used for actual emails. Sending messages to such addresses has a huge negative impact on reputation score,
    ///   “smtp_connection_failed” - the domain’s SMTP server does not respond; the address may contain a typo.
    /// </summary>
    [JsonPropertyName("cause")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Cause { get; set; }
    
    /// <summary>
    /// Validity score, from 0 to 100 (0 – invalid, 100 – valid).
    /// </summary>
    [JsonPropertyName("validity")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int Validity { get; set; }
    
    /// <summary>
    /// Local part (everything preceding the @ sign).
    /// </summary>
    [JsonPropertyName("local_part")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string LocalPart { get; set; }
    
    /// <summary>
    /// Domain name part.
    /// </summary>
    [JsonPropertyName("domain")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Domain { get; set; }
    
    /// <summary>
    /// True if the address’ domain does have an MX record, false if does not.
    /// </summary>
    [JsonPropertyName("mx_found")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool MxFound { get; set; }
    
    /// <summary>
    /// Preferred MX record for the domain.
    /// </summary>
    [JsonPropertyName("mx_record")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string MxRecord { get; set; }
    
    /// <summary>
    /// For addresses which are likely to have typing errors (cause=possible_typo), a suggested variant with a fixed typo.
    /// </summary>
    [JsonPropertyName("did_you_mean")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string DidYouMean { get; set; }
    
    /// <summary>
    /// Email check date and time, YYYY-MM-DD hh:mm:ss UTC.
    /// </summary>
    [JsonPropertyName("processed_at")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime ProcessedAt { get; set; }

    public EmailValidationData(){}

    private EmailValidationData(string status, string email, string cause, int validity, string local_part,
        string domain, bool mx_found, string mx_record, string did_you_mean, DateTime processed_at)
    {
        Status = status;
        Email = email;
        Cause = cause;
        Validity = validity;
        LocalPart = local_part;
        Domain = domain;
        MxFound = mx_found;
        MxRecord = mx_record;
        DidYouMean = did_you_mean;
        ProcessedAt = processed_at;
    }

    public static EmailValidationData CreateNew(string status, string email, string cause, int validity, string local_part, string domain, bool mx_found, string mx_record, string did_you_mean, DateTime processed_at)
    {
        return new  EmailValidationData(status, email, cause, validity, local_part, domain, mx_found, mx_record, did_you_mean, processed_at);
    }
}