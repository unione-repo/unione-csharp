namespace UniOneTests;

public class EmailResponseDataTests
{
    [Fact]
    public void EmailResponseData_InitializeWithDefaultValues()
    {
        // Arrange & Act
        var emailResponseData = new EmailResponseData();

        // Assert
        Assert.Null(emailResponseData.Status);
        Assert.Null(emailResponseData.JobId);
        Assert.Null(emailResponseData.Emails);
        Assert.Null(emailResponseData.FailedEmails);
    }

    [Fact]
    public void EmailResponseData_SetPropertyValues()
    {
        // Arrange
        var emailResponseData = new EmailResponseData();
        var emails = new List<string> { "recipient1@example.com", "recipient2@example.com" };
        var failedEmails = new Dictionary<string, string> { { "failed1@example.com", "error1" } };

        // Act
        emailResponseData.Status = "success";
        emailResponseData.JobId = "job123";
        emailResponseData.Emails = emails;
        emailResponseData.FailedEmails = failedEmails;

        // Assert
        Assert.Equal("success", emailResponseData.Status);
        Assert.Equal("job123", emailResponseData.JobId);
        Assert.Equal(emails, emailResponseData.Emails);
        Assert.Equal(failedEmails, emailResponseData.FailedEmails);
    }

    [Fact]
    public void EmailResponseData_FailedEmails_SetToNull()
    {
        // Arrange
        var emailResponseData = new EmailResponseData();
        var failedEmails = new Dictionary<string, string> { { "failed1@example.com", "error1" } };

        // Act
        emailResponseData.FailedEmails = null;

        // Assert
        Assert.Null(emailResponseData.FailedEmails);
    }
}