using System.Text.Json.Serialization;

namespace UniOne.Models;

public class TagData
{
    /// <summary>
    /// Unique tag id.
    /// </summary>
    [JsonPropertyName("tag_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int TagId { get; set; }
    
    /// <summary>
    /// Tag name.
    /// </summary>
    [JsonPropertyName("tag")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Tag { get; set; }

    public TagData(){}

    private TagData(int tagId, string tag)
    {
        TagId = tagId;
        Tag = tag;
    }

    public static TagData CreateNew(int tagId, string tag)
    {
        return new TagData(tagId, tag);
    }
}

public class TagList
{
    [JsonPropertyName("status")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Status { get; set; }
    
    [JsonPropertyName("tags")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<TagData> Tags { get; set; }
}