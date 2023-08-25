namespace UniOneTests;

public class AccountingDataTests
{
    [Fact]
    public void CreateNew_ValidData_ReturnsCorrectObject()
    {
        // Arrange
        DateTime periodStart = new DateTime(2023, 1, 1);
        DateTime periodEnd = new DateTime(2023, 1, 31);
        int emailsIncluded = 1000;
        int emailsSent = 800;

        // Act
        var accountingData = AccountingData.CreateNew(periodStart, periodEnd, emailsIncluded, emailsSent);

        // Assert
        Assert.NotNull(accountingData);
        Assert.Equal(periodStart, accountingData.PeriodStart);
        Assert.Equal(periodEnd, accountingData.PeriodEnd);
        Assert.Equal(emailsIncluded, accountingData.EmailsIncluded);
        Assert.Equal(emailsSent, accountingData.EmailsSent);
    }

    [Theory]
    [InlineData("2023-01-01", "2023-01-31", 1000, 800)]
    [InlineData("2023-02-01", "2023-02-28", 1200, 900)]
    public void CreateNew_ValidData_ReturnsCorrectObjectWithInlineData(string periodStartStr, string periodEndStr, int emailsIncluded, int emailsSent)
    {
        // Arrange
        DateTime periodStart = DateTime.Parse(periodStartStr);
        DateTime periodEnd = DateTime.Parse(periodEndStr);

        // Act
        var accountingData = AccountingData.CreateNew(periodStart, periodEnd, emailsIncluded, emailsSent);

        // Assert
        Assert.NotNull(accountingData);
        Assert.Equal(periodStart, accountingData.PeriodStart);
        Assert.Equal(periodEnd, accountingData.PeriodEnd);
        Assert.Equal(emailsIncluded, accountingData.EmailsIncluded);
        Assert.Equal(emailsSent, accountingData.EmailsSent);
    }
}