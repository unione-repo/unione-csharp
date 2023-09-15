using Allure.Xunit.Attributes;

namespace UniOneTests;

public class DomainDataTests
{
    [AllureXunit]
    public void CreateNew_ShouldReturnValidDomainData()
    {
        // Arrange

        // Act
        var domainData = DomainData.CreateNew("example.com", 20, 10);

        // Assert
        Assert.Equal("example.com", domainData.Domain);
        Assert.Equal(20, domainData.Limit);
        Assert.Equal(10, domainData.Offset);
    }
    
    [AllureXunit]
    public void CreateNew_ShouldReturnValidVerificationRecord()
    {
        // Arrange

        // Act
        var verificationRecord = VerificationRecord.CreateNew("value123", "verified");

        // Assert
        Assert.Equal("value123", verificationRecord.Value);
        Assert.Equal("verified", verificationRecord.Status);
    }
    
    [AllureXunit]
    public void CreateNew_ShouldReturnValidDKIM()
    {
        // Arrange

        // Act
        var dkim = DKIM.CreateNew("key123", "active");

        // Assert
        Assert.Equal("key123", dkim.Key);
        Assert.Equal("active", dkim.Status);
    }
}