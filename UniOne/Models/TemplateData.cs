using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace UniOne.Models;

public class TemplateData
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    /// <summary>
    /// Value from EditorType class
    /// </summary>
    [JsonProperty("editor_type")]
    public string EditorType { get; set; }
    /// <summary>
    /// Value from TemplateEngine class
    /// </summary>
    [JsonProperty("template_engine")]
    public string TemplateEngine { get; set; }
    [JsonProperty("global_substitutions")]
    public List<Dictionary<string,string>> GlobalSubstitutions { get; set; }
    [JsonProperty("global_metadata")]
    public List<Dictionary<string,string>> GlobalMetadata { get; set; }
    [JsonProperty("body")]
    public Body Body { get; set; }
    [JsonProperty("subject")]
    public string Subject { get; set; }
    [JsonProperty("from_email")]
    public string FromEmail { get; set; }
    [JsonProperty("from_name")]
    public string FromName { get; set; }
    [JsonProperty("reply_to")]
    public string ReplyTo { get; set; }
    [Range(0,1)]
    [JsonProperty("track_links")]
    public int TrackLinks { get; set; }
    [Range(0,1)]
    [JsonProperty("track_read")]
    public int TrackRead { get; set; }
    [JsonProperty("headers")]
    public List<Dictionary<string,string>> Headers { get; set; }
    [JsonProperty("attachments")]
    public List<Attachment> Attachments { get; set; }
    [JsonProperty("inline_attachments")]
    public List<Attachment> InlineAttachments { get; set; }
    [JsonProperty("created")]
    public string Created { get; set; }
    [JsonProperty("user_id")]
    public string UserId { get; set; }
    [JsonProperty("project_id")]
    public string ProjectId { get; set; }
    [JsonProperty("project_name")]
    public string ProjectName { get; set; }
}


public class Body
{
    /// <summary>
    /// HTML part of the email body
    /// </summary>
    [JsonProperty("html")]
    public string Html { get; set; }
    /// <summary>
    /// Plaintext part of the email body.
    /// </summary>
    [JsonProperty("plaintext")]
    public string PlainText { get; set; }
    /// <summary>
    /// Optional AMP part of the email body.
    /// </summary>
    [JsonProperty("amp")]
    public string Amp { get; set; }
}

public class Attachment
{
    /// <summary>
    /// Attachment type, see MIME. If unsure, use “application/octet-stream”.
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; }
    /// <summary>
    /// Attachment name in the format: “name.extension”
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
    /// <summary>
    /// File contents in base64. Maximum file size 7MB (9786710 bytes in base64).
    /// </summary>
    [JsonProperty("content")]
    public string Content { get; set; }
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
    public string? status;
    public IEnumerable<TemplateData> templates;
}