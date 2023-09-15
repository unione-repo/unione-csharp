using Allure.Xunit.Attributes;

namespace UniOneTests;

public class EmailValidationDataTests
{
    [AllureXunit]
    public void EmailValidationData_CreateNew_ReturnsValidInstance()
    {
        // Arrange
        string status = "valid";
        string email = "test@example.com";
        string cause = null;
        int validity = 1;
        string local_part = "test";
        string domain = "example.com";
        bool mx_found = true;
        string mx_record = "mail.example.com";
        string did_you_mean = null;
        DateTime processed_at = DateTime.UtcNow;

        // Act
        var validationData = EmailValidationData.CreateNew(status, email, cause, validity, local_part, domain, mx_found, mx_record, did_you_mean, processed_at);

        // Assert
        Assert.NotNull(validationData);
        Assert.Equal(status, validationData.Status);
        Assert.Equal(email, validationData.Email);
        Assert.Equal(cause, validationData.Cause);
        Assert.Equal(validity, validationData.Validity);
        Assert.Equal(local_part, validationData.LocalPart);
        Assert.Equal(domain, validationData.Domain);
        Assert.Equal(mx_found, validationData.MxFound);
        Assert.Equal(mx_record, validationData.MxRecord);
        Assert.Equal(did_you_mean, validationData.DidYouMean);
        Assert.Equal(processed_at, validationData.ProcessedAt);
    }

    [AllureXunit]
    public void EmailValidationData_PrivateConstructor_CreatesValidInstance()
    {
        // Arrange
        string status = "valid";
        string email = "test@example.com";
        string cause = null;
        int validity = 1;
        string local_part = "test";
        string domain = "example.com";
        bool mx_found = true;
        string mx_record = "mail.example.com";
        string did_you_mean = null;
        DateTime processed_at = DateTime.UtcNow;

        // Act
        var validationData = EmailValidationData.CreateNew(status, email, cause, validity, local_part, domain, mx_found, mx_record, did_you_mean, processed_at);

        // Assert
        Assert.NotNull(validationData);
        Assert.Equal(status, validationData.Status);
        Assert.Equal(email, validationData.Email);
        Assert.Equal(cause, validationData.Cause);
        Assert.Equal(validity, validationData.Validity);
        Assert.Equal(local_part, validationData.LocalPart);
        Assert.Equal(domain, validationData.Domain);
        Assert.Equal(mx_found, validationData.MxFound);
        Assert.Equal(mx_record, validationData.MxRecord);
        Assert.Equal(did_you_mean, validationData.DidYouMean);
        Assert.Equal(processed_at, validationData.ProcessedAt);
    }
}