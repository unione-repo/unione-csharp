using Newtonsoft.Json;

namespace UniOne.Models;

public class TagData
{
    /// <summary>
    /// Unique tag id.
    /// </summary>
    [JsonProperty("tag_id")]
    public int TagId { get; set; }
    /// <summary>
    /// Tag name.
    /// </summary>
    [JsonProperty("tag")]
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
    [JsonProperty("status")]
    public string Status { get; set; }
    [JsonProperty("tags")]
    public IEnumerable<TagData> Tags { get; set; }
}