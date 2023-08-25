using System.Reflection;

namespace UniOneTests;

public class UnsubscibedDataTests
{
    [Fact]
    public void UnsubscribedData_CreateNew_ReturnsValidInstance()
    {
        // Arrange
        string emailAddress = "test@example.com";
        DateTime unsubscribedOn = DateTime.UtcNow;
        bool isUnsubscribed = true;
        string message = "User unsubscribed.";

        // Act
        var unsubscribedData = UnsubscribedData.CreateNew(emailAddress, unsubscribedOn, isUnsubscribed, message);

        // Assert
        Assert.NotNull(unsubscribedData);
        Assert.Equal(emailAddress, unsubscribedData.EmailAddress);
        Assert.Equal(unsubscribedOn, unsubscribedData.UnsubscribedOn);
        Assert.True(unsubscribedData.IsUnsubscribed);
        Assert.Equal(message, unsubscribedData.Message);
    }

    [Fact]
    public void UnsubscribedData_PrivateConstructor_Test()
    {
        // Arrange
        string emailAddress = "test@example.com";
        DateTime unsubscribedOn = DateTime.UtcNow;
        bool isUnsubscribed = true;
        string message = "User unsubscribed.";

        // Act
        var constructorInfo = typeof(UnsubscribedData).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(string), typeof(DateTime), typeof(bool), typeof(string) }, null);
        UnsubscribedData unsubscribedData = (UnsubscribedData)constructorInfo.Invoke(new object[] { emailAddress, unsubscribedOn, isUnsubscribed, message });

        // Assert
        Assert.NotNull(unsubscribedData);
        Assert.Equal(emailAddress, unsubscribedData.EmailAddress);
        Assert.Equal(unsubscribedOn, unsubscribedData.UnsubscribedOn);
        Assert.True(unsubscribedData.IsUnsubscribed);
        Assert.Equal(message, unsubscribedData.Message);
    }
}