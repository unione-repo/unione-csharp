using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UniOne.Models;

public class TemplateData
{
    [JsonPropertyName("id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Id { get; set; }
    
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }
    
    /// <summary>
    /// Value from EditorType class
    /// </summary>
    [JsonPropertyName("editor_type")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? EditorType { get; set; }
    
    /// <summary>
    /// Value from TemplateEngine class
    /// </summary>
    [JsonPropertyName("template_engine")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? TemplateEngine { get; set; }
    
    [JsonPropertyName("global_substitutions")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Dictionary<string,string>>? GlobalSubstitutions { get; set; }
    
    [JsonPropertyName("global_metadata")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Dictionary<string,string>>? GlobalMetadata { get; set; }
    
    [JsonPropertyName("body")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Body? Body { get; set; }
    
    [JsonPropertyName("subject")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Subject { get; set; }
    
    [JsonPropertyName("from_email")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FromEmail { get; set; }
    
    [JsonPropertyName("from_name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FromName { get; set; }
    
    [JsonPropertyName("reply_to")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ReplyTo { get; set; }
    
    [Range(0,1)]
    [JsonPropertyName("track_links")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int TrackLinks { get; set; }
    
    [Range(0,1)]
    [JsonPropertyName("track_read")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int TrackRead { get; set; }
    
    [JsonPropertyName("headers")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Dictionary<string,string>>? Headers { get; set; }
    
    [JsonPropertyName("attachments")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Attachment>? Attachments { get; set; }
    
    [JsonPropertyName("inline_attachments")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Attachment>? InlineAttachments { get; set; }
    
    [JsonPropertyName("created")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Created { get; set; }
    
    [JsonPropertyName("user_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? UserId { get; set; }
    
    [JsonPropertyName("project_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ProjectId { get; set; }
    
    [JsonPropertyName("project_name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ProjectName { get; set; }
    
    public string ToJson()
    {
        var jsonObject = new Dictionary<string, object>
        {
            ["template"] = new Dictionary<string, object>()
        };

        PropertyInfo[] properties = typeof(EmailMessageData).GetProperties();
        foreach (PropertyInfo property in properties)
        {
            string propertyName = GetJsonPropertyName(property);
            
            object? propertyValue = property.GetValue(this);
            
            if (propertyValue != null)
            {
                ((Dictionary<string, object?>)jsonObject["message"])[propertyName] = propertyValue;
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


public class Body
{
    /// <summary>
    /// HTML part of the email body
    /// </summary>
    [JsonPropertyName("html")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Html { get; set; }
    
    /// <summary>
    /// Plaintext part of the email body.
    /// </summary>
    [JsonPropertyName("plaintext")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? PlainText { get; set; }
    
    /// <summary>
    /// Optional AMP part of the email body.
    /// </summary>
    [JsonPropertyName("amp")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Amp { get; set; }
}

public class Attachment
{
    /// <summary>
    /// Attachment type, see MIME. If unsure, use “application/octet-stream”.
    /// </summary>
    [JsonPropertyName("type")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Type { get; set; }
    
    /// <summary>
    /// Attachment name in the format: “name.extension”
    /// </summary>
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }
    
    /// <summary>
    /// File contents in base64. Maximum file size 7MB (9786710 bytes in base64).
    /// </summary>
    [JsonPropertyName("content")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Content { get; set; }
}

public class EditorType
{
    public const string Html = "html";
    public const string Visual = "visual";
}

public class TemplateEngine
{
    public const string None = "none";
    public const string Simple = "simple";
    public const string Velocity = "velocity";
}

public class InputData
{
    public string? Id { get; set; }
    public int? Limit { get; set; }
    public int? Offset { get; set; }

    private InputData(string? id, int? limit, int? offset)
    {
        Id = id;
        Limit = limit;
        Offset = offset;
    }
    
    public static InputData CreateNew(string? id, int? limit, int? offset)
    {
        return new InputData(id, limit, offset);
    }
}

public class TemplateList
{
    [JsonPropertyName("status")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? status;
    
    [JsonPropertyName("templates")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]

    public IEnumerable<TemplateData>? templates;
}