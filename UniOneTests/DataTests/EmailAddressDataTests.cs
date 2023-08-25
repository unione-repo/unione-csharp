namespace UniOneTests;

public class EmailAddressDataTests
{
    [Fact]
    public void EmailAddressData_ConstructedWithValues_HasCorrectProperties()
    {
        // Arrange
        string address = "test@example.com";

        // Act
        var emailAddressData = new EmailAddressData
        {
            Address = address
        };

        // Assert
        Assert.NotNull(emailAddressData);
        Assert.Equal(address, emailAddressData.Address);
    }

    [Fact]
    public void EmailAddressData_CreateNew_ReturnsCorrectObject()
    {
        // Arrange
        string address = "test@example.com";

        // Act
        var emailAddressData = EmailAddressData.CreateNew(address);

        // Assert
        Assert.NotNull(emailAddressData);
        Assert.Equal(address, emailAddressData.Address);
    }
}