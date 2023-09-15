using Allure.Xunit.Attributes;

namespace UniOneTests;

public class EmailMessageDataTests
{
    [AllureXunit]
    public void Options_InitializeWithDefaultValues()
    {
        // Arrange & Act
        var options = new Options();

        // Assert
        Assert.Null(options.SendAt);
        Assert.Null(options.UnsubscribeUrl);
        Assert.Null(options.CustomBackendId);
        Assert.Null(options.SmtpPoolId);
    }

    [AllureXunit]
    public void Options_SetPropertyValues()
    {
        // Arrange
        var options = new Options();

        // Act
        options.SendAt = "2023-08-21";
        options.UnsubscribeUrl = "https://example.com/unsubscribe";
        options.CustomBackendId = 1;
        options.SmtpPoolId = "pool123";

        // Assert
        Assert.Equal("2023-08-21", options.SendAt);
        Assert.Equal("https://example.com/unsubscribe", options.UnsubscribeUrl);
        Assert.Equal(1, options.CustomBackendId);
        Assert.Equal("pool123", options.SmtpPoolId);
    }

    [AllureXunit]
    public void Options_CustomBackendId_SetToNull()
    {
        // Arrange
        var options = new Options();

        // Act
        options.CustomBackendId = null;

        // Assert
        Assert.Null(options.CustomBackendId);
    }
    
    [AllureXunit]
    public void EmailMessageData_InitializeWithDefaultValues()
    {
        // Arrange & Act
        var emailMessageData = new EmailMessageData();

        // Assert
        Assert.Null(emailMessageData.Recipients);
        Assert.Null(emailMessageData.TemplateId);
        Assert.Null(emailMessageData.Tags);
        Assert.Null(emailMessageData.SkipUnsubscribe);
        Assert.Null(emailMessageData.GlobalLanguage);
        Assert.Null(emailMessageData.TemplateEngine);
        Assert.Null(emailMessageData.GlobalSubstitutions);
        Assert.Null(emailMessageData.GlobalMetadata);
        Assert.Null(emailMessageData.Body);
        Assert.Null(emailMessageData.Subject);
        Assert.Null(emailMessageData.FromEmail);
        Assert.Null(emailMessageData.FromName);
        Assert.Null(emailMessageData.ReplyTo);
        Assert.Null(emailMessageData.TrackLinks);
        Assert.Null(emailMessageData.TrackRead);
        Assert.Null(emailMessageData.BypassGlobal);
        Assert.Null(emailMessageData.BypassUnavailable);
        Assert.Null(emailMessageData.BypassUnsubscribed);
        Assert.Null(emailMessageData.BypassComplained);
        Assert.Null(emailMessageData.Headers);
        Assert.Null(emailMessageData.Attachments);
        Assert.Null(emailMessageData.InlineAttachments);
        Assert.Null(emailMessageData.Options);
    }

    [AllureXunit]
    public void EmailMessageData_Options_SetToNonNull()
    {
        // Arrange
        var emailMessageData = new EmailMessageData();
        var options = new Options();

        // Act
        emailMessageData.Options = options;

        // Assert
        Assert.Equal(options, emailMessageData.Options);
    }
    
    [AllureXunit]
    public void EmailMessageData_SetPropertyValues()
    {
        // Arrange
        var emailMessageData = new EmailMessageData();
        var recipients = new List<EmailRecipientData> { new EmailRecipientData { EmailAddress = "recipient@example.com" } };
        var globalSubstitutions = new Dictionary<string, string> { { "key1", "value1" } };
        var headers = new Dictionary<string, string> { { "Header1", "Value1" } };
        var attachments = new List<Attachment> { new Attachment { Name = "attachment.txt" } };
        var inlineAttachments = new List<Attachment> { new Attachment { Name = "image.jpg" } };
        var options = new Options { SendAt = "2023-08-21" };

        // Act
        emailMessageData.Recipients = recipients;
        emailMessageData.TemplateId = "template123";
        emailMessageData.Tags = new List<string> { "tag1", "tag2" };
        emailMessageData.SkipUnsubscribe = 1;
        emailMessageData.GlobalLanguage = "en-US";
        emailMessageData.TemplateEngine = "Razor";
        emailMessageData.GlobalSubstitutions = globalSubstitutions;
        emailMessageData.GlobalMetadata = new Dictionary<string, string> { { "meta1", "value1" } };
        emailMessageData.Body = new Body { PlainText = "Hello World" };
        emailMessageData.Subject = "Test Email";
        emailMessageData.FromEmail = "sender@example.com";
        emailMessageData.FromName = "Sender Name";
        emailMessageData.ReplyTo = "replyto@example.com";
        emailMessageData.TrackLinks = 1;
        emailMessageData.TrackRead = 1;
        emailMessageData.BypassGlobal = 1;
        emailMessageData.BypassUnavailable = 1;
        emailMessageData.BypassUnsubscribed = 1;
        emailMessageData.BypassComplained = 1;
        emailMessageData.Headers = headers;
        emailMessageData.Attachments = attachments;
        emailMessageData.InlineAttachments = inlineAttachments;
        emailMessageData.Options = options;

        // Assert
        Assert.Equal(recipients, emailMessageData.Recipients);
        Assert.Equal("template123", emailMessageData.TemplateId);
        Assert.Equal(new List<string> { "tag1", "tag2" }, emailMessageData.Tags);
        Assert.Equal(1, emailMessageData.SkipUnsubscribe);
        Assert.Equal("en-US", emailMessageData.GlobalLanguage);
        Assert.Equal("Razor", emailMessageData.TemplateEngine);
        Assert.Equal(globalSubstitutions, emailMessageData.GlobalSubstitutions);
        Assert.Equal(new Dictionary<string, string> { { "meta1", "value1" } }, emailMessageData.GlobalMetadata);
        Assert.Equal("Hello World", emailMessageData.Body.PlainText);
        Assert.Equal("Test Email", emailMessageData.Subject);
        Assert.Equal("sender@example.com", emailMessageData.FromEmail);
        Assert.Equal("Sender Name", emailMessageData.FromName);
        Assert.Equal("replyto@example.com", emailMessageData.ReplyTo);
        Assert.Equal(1, emailMessageData.TrackLinks);
        Assert.Equal(1, emailMessageData.TrackRead);
        Assert.Equal(1, emailMessageData.BypassGlobal);
        Assert.Equal(1, emailMessageData.BypassUnavailable);
        Assert.Equal(1, emailMessageData.BypassUnsubscribed);
        Assert.Equal(1, emailMessageData.BypassComplained);
        Assert.Equal(headers, emailMessageData.Headers);
        Assert.Equal(attachments, emailMessageData.Attachments);
        Assert.Equal(inlineAttachments, emailMessageData.InlineAttachments);
        Assert.Equal(options, emailMessageData.Options);
    }
}