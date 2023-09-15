using Allure.Xunit.Attributes;

namespace UniOneTests;

public class SystemInfoDataTests
{
    [AllureXunit]
    public void SystemInfoData_InitializeWithDefaultValues()
    {
        // Arrange & Act
        var systemInfoData = new SystemInfoData();

        // Assert
        Assert.Null(systemInfoData.Status);
        Assert.Equal(0, systemInfoData.UserId);
        Assert.Null(systemInfoData.EmailAddress);
        Assert.Null(systemInfoData.ProjectId);
        Assert.Null(systemInfoData.ProjectName);
        Assert.Null(systemInfoData.Accounting);
    }

    [AllureXunit]
    public void SystemInfoData_CreateNew_ReturnsValidInstance()
    {
        // Arrange
        string status = "active";
        int userId = 123;
        string email = "test@example.com";
        string projectId = "project123";
        string projectName = "Project Name";
        DateTime periodStart = DateTime.UtcNow.AddMonths(-1);
        DateTime periodEnd = DateTime.UtcNow;
        int emailsIncluded = 1000;
        int emailSent = 500;

        // Act
        var systemInfoData = SystemInfoData.CreateNew(status, userId, email, projectId, projectName, periodStart, periodEnd, emailsIncluded, emailSent);

        // Assert
        Assert.NotNull(systemInfoData);
        Assert.Equal(status, systemInfoData.Status);
        Assert.Equal(userId, systemInfoData.UserId);
        Assert.Equal(email, systemInfoData.EmailAddress);
        Assert.Equal(projectId, systemInfoData.ProjectId);
        Assert.Equal(projectName, systemInfoData.ProjectName);
        Assert.NotNull(systemInfoData.Accounting);
        Assert.Equal(periodStart, systemInfoData.Accounting.PeriodStart);
        Assert.Equal(periodEnd, systemInfoData.Accounting.PeriodEnd);
        Assert.Equal(emailsIncluded, systemInfoData.Accounting.EmailsIncluded);
        Assert.Equal(emailSent, systemInfoData.Accounting.EmailsSent);
    }
}