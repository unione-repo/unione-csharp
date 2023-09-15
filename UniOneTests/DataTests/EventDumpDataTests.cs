using Allure.Xunit.Attributes;

namespace UniOneTests;

public class EventDumpDataTests
{
    [AllureXunit]
    public void DeliveryStatus_ConstantsAreCorrect()
    {
        // Assert
        Assert.Equal("err_user_unknown", DeliveryStatus.Err_user_unknown);
        Assert.Equal("err_user_inactive", DeliveryStatus.Err_user_inactive);
        Assert.Equal("err_will_retry", DeliveryStatus.Err_will_retry);
        Assert.Equal("err_mailbox_discarded", DeliveryStatus.Err_mailbox_discarded);
        Assert.Equal("err_mailbox_full", DeliveryStatus.Err_mailbox_full);
        Assert.Equal("err_spam_rejected", DeliveryStatus.Err_spam_rejected);
        Assert.Equal("err_blacklisted", DeliveryStatus.Err_blacklisted);
        Assert.Equal("err_too_large", DeliveryStatus.Err_too_large);
        Assert.Equal("err_unsubscribed", DeliveryStatus.Err_unsubscribed);
        Assert.Equal("err_unreachable", DeliveryStatus.Err_unreachable);
        Assert.Equal("err_skip_letter", DeliveryStatus.Err_skip_letter);
        Assert.Equal("err_domain_inactive", DeliveryStatus.Err_domain_inactive);
        Assert.Equal("err_destination_misconfigured", DeliveryStatus.Err_destination_misconfigured);
        Assert.Equal("err_delivery_failed", DeliveryStatus.Err_delivery_failed);
        Assert.Equal("err_spam_skipped", DeliveryStatus.Err_spam_skipped);
        Assert.Equal("err_lost", DeliveryStatus.Err_lost);
    }
    
    [AllureXunit]
    public void EventDumpStatus_ConstantsAreCorrect()
    {
        // Assert
        Assert.Equal("sent", EventDumpStatus.Sent);
        Assert.Equal("delivered", EventDumpStatus.Delivered);
        Assert.Equal("opened", EventDumpStatus.Opened);
        Assert.Equal("clicked", EventDumpStatus.Clicked);
        Assert.Equal("unsubscribed", EventDumpStatus.Unsubscribed);
        Assert.Equal("soft_bounced", EventDumpStatus.Soft_bounced);
        Assert.Equal("hard_bounced", EventDumpStatus.Hard_bounced);
        Assert.Equal("spam", EventDumpStatus.Spam);
    }
    
    [AllureXunit]
    public void EventDumpRequest_InitializeWithDefaultValues()
    {
        // Arrange & Act
        var eventDumpRequest = new EventDumpRequest();

        // Assert
        Assert.Null(eventDumpRequest.StartTime);
        Assert.Null(eventDumpRequest.EndTime);
        Assert.Null(eventDumpRequest.Limit);
        Assert.Null(eventDumpRequest.AllProjects);
        Assert.Null(eventDumpRequest.Filter);
        Assert.Null(eventDumpRequest.Delimiter);
        Assert.Null(eventDumpRequest.Format);
    }

    [AllureXunit]
    public void EventDumpRequest_SetPropertyValues()
    {
        // Arrange
        var eventDumpRequest = new EventDumpRequest();
        var filter = new EventDumpFilter();

        // Act
        eventDumpRequest.StartTime = "2023-08-21";
        eventDumpRequest.EndTime = "2023-08-22";
        eventDumpRequest.Limit = 100;
        eventDumpRequest.AllProjects = true;
        eventDumpRequest.Filter = filter;
        eventDumpRequest.Delimiter = ",";
        eventDumpRequest.Format = "json";

        // Assert
        Assert.Equal("2023-08-21", eventDumpRequest.StartTime);
        Assert.Equal("2023-08-22", eventDumpRequest.EndTime);
        Assert.Equal(100, eventDumpRequest.Limit);
        Assert.True(eventDumpRequest.AllProjects);
        Assert.Equal(filter, eventDumpRequest.Filter);
        Assert.Equal(",", eventDumpRequest.Delimiter);
        Assert.Equal("json", eventDumpRequest.Format);
    }
    
    [AllureXunit]
    public void EventDumpFilter_InitializeWithDefaultValues()
    {
        // Arrange & Act
        var eventDumpFilter = new EventDumpFilter();

        // Assert
        Assert.Null(eventDumpFilter.JobId);
        Assert.Null(eventDumpFilter.Status);
        Assert.Null(eventDumpFilter.DeliveryStatus);
        Assert.Null(eventDumpFilter.Email);
        Assert.Null(eventDumpFilter.EmailFrom);
        Assert.Null(eventDumpFilter.Domain);
        Assert.Null(eventDumpFilter.CampaignId);
    }

    [AllureXunit]
    public void EventDumpFilter_SetPropertyValues()
    {
        // Arrange
        var eventDumpFilter = new EventDumpFilter();

        // Act
        eventDumpFilter.JobId = "job123";
        eventDumpFilter.Status = EventDumpStatus.Sent;
        eventDumpFilter.DeliveryStatus = DeliveryStatus.Err_user_unknown;
        eventDumpFilter.Email = "test@example.com";
        eventDumpFilter.EmailFrom = "sender@example.com";
        eventDumpFilter.Domain = "example.com";
        eventDumpFilter.CampaignId = "campaign123";

        // Assert
        Assert.Equal("job123", eventDumpFilter.JobId);
        Assert.Equal(EventDumpStatus.Sent, eventDumpFilter.Status);
        Assert.Equal(DeliveryStatus.Err_user_unknown, eventDumpFilter.DeliveryStatus);
        Assert.Equal("test@example.com", eventDumpFilter.Email);
        Assert.Equal("sender@example.com", eventDumpFilter.EmailFrom);
        Assert.Equal("example.com", eventDumpFilter.Domain);
        Assert.Equal("campaign123", eventDumpFilter.CampaignId);
    }
}