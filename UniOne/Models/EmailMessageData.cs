using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UniOne.Models;


public class Options
{
    /// <summary>
    /// Date and time in “YYYY-MM-DD hh:mm:ss” format in the UTC timezone. Allows schedule sending up to 24 hours in advance.
    /// </summary>
    [JsonPropertyName("send_at")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SendAt { get; set; }
    
    /// <summary>
    /// Custom unsubscribe link. Read more here - https://docs.unione.io/en/unsubscribe-link
    /// </summary>
    [JsonPropertyName("unsubscribe_url")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? UnsubscribeUrl { get; set; }
    
    /// <summary>
    /// Backend-domain identifier to send message with. If custom_backend_id is not set, default one for your account/project will be used. You can pay for one or more dedicated IPs and use this option.
    /// </summary>
    [JsonPropertyName("custom_backend_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? CustomBackendId { get; set; }
    
    /// <summary>
    /// SMTP pool identifier to send message with. If smtp_pool_id is not set, default one for your account/project will be used. You can pay for one or more dedicated IPs and use this option to choose sending using dedicated IP or common pool.
    /// </summary>
    [JsonPropertyName("smtp_pool_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SmtpPoolId { get; set; }
}

public class EmailMessageData
{
    /// <summary>
    /// Contains recipient emails, substitutions(merge tags) and metadata.
    /// </summary>
    [JsonPropertyName("recipients")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<EmailRecipientData>? Recipients { get; set; }
    
    /// <summary>
    /// Optional identifier of the template that had been created by template/set method. If template_id is passed then fields from the template are used instead of missed email/send parameters. E.g. if “body” parameter in email/send is omitted, “body” from template will be used. If “subject” in email/send is omitted, “subject” from template will be used.
    /// </summary>
    [JsonPropertyName("template_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? TemplateId { get; set; }
    
    /// <summary>
    /// An array of strings. The maximum string length is 50 characters. You can include up to 4 strings which must be unique. No more than 10 000 tags are allowed per project; if you try to add more, email/send will return an error. You may use tags to categorize emails by your own criteria, and they will be passed along by event-dump methods.
    /// </summary>
    [JsonPropertyName("tags")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>? Tags { get; set; }
    
    /// <summary>
    /// Whether to skip or not appending default unsubscribe footer. 1=skip, 0=append, default is 0. You should ask support to approve
    /// </summary>
    [JsonPropertyName("skip_unsubscribe")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? SkipUnsubscribe { get; set; }
    
    /// <summary>
    /// The language of the unsubscribe footer and unsubscribe page. Languages supported are: “be”, “de”, “en”, “es”, “fr”, “it”, “pl”, “pt”, “ru”, “ua”.
    /// </summary>
    [JsonPropertyName("global_language")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? GlobalLanguage { get; set; }
    
    /// <summary>
    /// The template engine for handling the substitutions(merge tags), “simple”, “velocity” or “none”. Default value is “simple”. “none” is only available for emails with “track_links” and “track_read” equal to 0 and the unsubscription link turned off.
    /// </summary>
    [JsonPropertyName("template_engine")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? TemplateEngine { get; set; }
    
    /// <summary>
    /// Object for passing the substitutions(merge tags) common for all recipients - e.g., company name. If the substitution names are duplicated in object “substitutions”, the values of the variables will be taken from the object “substitutions”. The substitutions can be used in the following parameters:
    /// </summary>
    [JsonPropertyName("global_substitutions")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string>? GlobalSubstitutions { get; set; }
    
    /// <summary>
    /// Object for passing the metadata common for all the recipients, such as “key”: “value”. Max key quantity: 10. Max key length: 64 symbols. Max value length: 1024 symbols. The metadata is returned by webhook.
    /// </summary>
    [JsonPropertyName("global_metadata")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string>? GlobalMetadata { get; set; }
    
    /// <summary>
    /// Contains HTML/plaintext/AMP parts of the email. Either html or plaintext part is required.
    /// </summary>
    [JsonPropertyName("body")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Body? Body { get; set; }
    
    /// <summary>
    /// Email subject.
    /// </summary>
    [JsonPropertyName("subject")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Subject { get; set; }
    
    /// <summary>
    /// Sender’s email. Required only if template_id parameter is empty.
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
    /// Optional Reply-To email (in case it’s different to sender’s email)
    /// </summary>
    [JsonPropertyName("reply_to")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ReplyTo { get; set; }
    
    /// <summary>
    /// 1=click tracking is on (default), 0=click tracking is off
    /// </summary>
    [JsonPropertyName("track_links")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? TrackLinks { get; set; }
    
    /// <summary>
    /// 1=read tracking is on (default), 0=read tracking is off.
    /// </summary>
    [JsonPropertyName("track_read")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? TrackRead { get; set; }
    
    /// <summary>
    /// (allowed values 0 or 1, default 0) If set to 1, the global unavailability list will be ignored. Even if the address was found to be unreachable while sending other UniOne users’ emails, or its owner has issued complaints, the message will still be sent. The setting may be ignored for certain addresses.
    /// </summary>
    [JsonPropertyName("bypass_global")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? BypassGlobal { get; set; }
    
    /// <summary>
    /// (allowed values 0 or 1, default 0) If set to 1, the current user’s or project’s unavailability list will be ignored. Works only if bypass_global is set to 1.
    /// </summary>
    [JsonPropertyName("bypass_unavailable")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? BypassUnavailable { get; set; }
    
    /// <summary>
    /// (allowed values 0 or 1, default 0) If set to 1, the current list of unsubscribed addresses for this account or project will be ignored. Works only if bypass_global is set to 1. The setting is available only for users that have been granted the right to omit the unsubscribe link (to request, please contact support).
    /// </summary>
    [JsonPropertyName("bypass_unsubscribed")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? BypassUnsubscribed { get; set; }
    
    /// <summary>
    /// (allowed values 0 or 1, default 0) If set to 1, the user’s or project’s complaint list will be ignored. Works only if bypass_global is set to 1. The setting is available only for users that have been granted the right to omit the unsubscribe link (to request, please contact support).
    /// </summary>
    [JsonPropertyName("bypass_complained")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? BypassComplained { get; set; }
    
    /// <summary>
    /// Contains email headers, maximum 50. Only headers with “X-” name prefix are accepted, all other are ignored, for example X-UNIONE-Global-Language, X-UNIONE-Template-Engine. If our support have approved omitting standard unsubscription block for you, you can also pass List-Unsubscribe, List-Subscribe, List-Help, List-Owner, List-Archive, In-Reply-To and References headers.
    /// X-UNIONE-Global-Language - The language of the unsubscribe footer and unsubscribe page. Languages supported are: “be”, “de”, “en”, “es”, “fr”, “it”, “pl”, “pt”, “ru”, “ua”.
    /// X-UNIONE-Template-Engine - The template engine for handling the substitutions(merge tags), “simple” or “velocity”. Default value is “simple”. Has a priority over the value allowed in the “template_engine” parameter.
    /// </summary>
    [JsonPropertyName("headers")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string>? Headers { get; set; }
    
    /// <summary>
    /// Optional array of attachments
    /// </summary>
    [JsonPropertyName("attachments")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Attachment>? Attachments { get; set; }
    
    /// <summary>
    /// Optional array of inline attachments, e.g. for including images in email instead of loading them from external URL.
    /// </summary>
    [JsonPropertyName("inline_attachments")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Attachment>? InlineAttachments { get; set; }
    
    /// <summary>
    /// Additional message options.
    /// </summary>
    [JsonPropertyName("options")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Options? Options { get; set; }
    
    public string ToJson()
    {
        var jsonObject = new Dictionary<string, object>
        {
            ["message"] = new Dictionary<string, object>()
        };

        PropertyInfo[] properties = typeof(EmailMessageData).GetProperties();
        foreach (PropertyInfo property in properties)
        {
            string propertyName = GetJsonPropertyName(property);
            
            object? propertyValue = property.GetValue(this);
            
            if (propertyValue != null)
            {
                ((Dictionary<string, object>)jsonObject["message"])[propertyName] = propertyValue;
            }
        }

        return JsonSerializer.Serialize(jsonObject, new JsonSerializerOptions
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        });
    }
    
    private static string GetJsonPropertyName(PropertyInfo property)
    {
        var attribute = property.GetCustomAttribute<JsonPropertyNameAttribute>();
        return attribute?.Name ?? property.Name;
    }
}