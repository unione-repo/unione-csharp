namespace UniOneTests;

public class WebhookDataTests
{
    [Fact]
    public void EmailStatus_ConstantsAreCorrect()
    {
        // Assert
        Assert.Equal("delivered", EmailStatus.Delivered);
        Assert.Equal("opened", EmailStatus.Opened);
        Assert.Equal("clicked", EmailStatus.Clicked);
        Assert.Equal("unsubscribed", EmailStatus.Unsubscribed);
        Assert.Equal("soft_bounced", EmailStatus.Soft_bounced);
        Assert.Equal("hard_bounced", EmailStatus.Hard_bounced);
        Assert.Equal("spam", EmailStatus.Spam);
    }
    
    [Fact]
    public void Event_InitializeWithDefaultValues()
    {
        // Arrange & Act
        var webhookEvent = new Event();

        // Assert
        Assert.Null(webhookEvent.Spam_block);
        Assert.Null(webhookEvent.Email_status);
    }
    
    [Fact]
    public void EventFormat_ConstantsAreCorrect()
    {
        // Assert
        Assert.Equal("json_post", EventFormat.Json_Post);
        Assert.Equal("json_post_gzip", EventFormat.Json_Post_Gzip);
    }
    
    [Fact]
    public void WebhookStatus_ConstantsAreCorrect()
    {
        // Assert
        Assert.Equal("active", WebhookStatus.Active);
        Assert.Equal("disabled", WebhookStatus.Disabled);
    }
    
    [Fact]
    public void WebhookData_InitializeWithDefaultValues()
    {
        // Arrange & Act
        var webhookData = new WebhookData();

        // Assert
        Assert.Null(webhookData.Id);
        Assert.Null(webhookData.Url);
        Assert.Null(webhookData.Status);
        Assert.Null(webhookData.EventFormat);
        Assert.Null(webhookData.DeliveryInfo);
        Assert.Null(webhookData.SingleEvent);
        Assert.Null(webhookData.MaxParallel);
        Assert.Null(webhookData.Events);
        Assert.Null(webhookData.UpdatedAt);
    }
}