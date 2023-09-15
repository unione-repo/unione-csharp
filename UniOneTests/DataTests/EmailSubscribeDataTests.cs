using Allure.Xunit.Attributes;

namespace UniOneTests;

public class EmailSubscribeDataTests
{
    [AllureXunit]
    public void EmailSubscribeData_CreateNew_ReturnsValidInstance()
    {
        // Arrange
        string fromEmail = "from@example.com";
        string fromName = "Sender Name";
        string toEmail = "to@example.com";

        // Act
        var emailSubscribeData = EmailSubscribeData.CreateNew(fromEmail, fromName, toEmail);

        // Assert
        Assert.NotNull(emailSubscribeData);
        Assert.Equal(fromEmail, emailSubscribeData.FromEmail);
        Assert.Equal(fromName, emailSubscribeData.FromName);
        Assert.Equal(toEmail, emailSubscribeData.ToEmail);
    }

    [AllureXunit]
    public void EmailSubscribeData_PrivateConstructor_CreatesValidInstance()
    {
        // Arrange
        string fromEmail = "from@example.com";
        string fromName = "Sender Name";
        string toEmail = "to@example.com";

        // Act
        var emailSubscribeData = EmailSubscribeData.CreateNew(fromEmail, fromName, toEmail);

        // Assert
        Assert.NotNull(emailSubscribeData);
        Assert.Equal(fromEmail, emailSubscribeData.FromEmail);
        Assert.Equal(fromName, emailSubscribeData.FromName);
        Assert.Equal(toEmail, emailSubscribeData.ToEmail);
    }
}