namespace UniOneTests;

public class SuppressionDataTests
{
    [Fact]
    public void SuppressionCause_ConstantsAreCorrect()
    {
        // Assert
        Assert.Equal("unsubscribed", SuppressionCause.Unsubscribed);
        Assert.Equal("temporary_unavailable", SuppressionCause.TemporaryUnavailable);
        Assert.Equal("permanent_unavailable", SuppressionCause.PermanentUnavailable);
        Assert.Equal("complained", SuppressionCause.Complained);
    }
    
    [Fact]
    public void SuppressionInputData_InitializeWithDefaultValues()
    {
        // Arrange & Act
        var suppressionInputData = new SuppressionInputData();

        // Assert
        Assert.Null(suppressionInputData.Email);
        Assert.Null(suppressionInputData.Cause);
        Assert.Equal(DateTime.MinValue, suppressionInputData.Created);
        Assert.False(suppressionInputData.AllProjects);
    }

    [Fact]
    public void SuppressionInputData_CreateNew_ReturnsValidInstance()
    {
        // Arrange
        string email = "test@example.com";
        string cause = SuppressionCause.Unsubscribed;
        DateTime created = DateTime.UtcNow;
        bool allProjects = true;

        // Act
        var suppressionInputData = SuppressionInputData.CreateNew(email, cause, created, allProjects);

        // Assert
        Assert.NotNull(suppressionInputData);
        Assert.Equal(email, suppressionInputData.Email);
        Assert.Equal(cause, suppressionInputData.Cause);
        Assert.Equal(created, suppressionInputData.Created);
        Assert.True(suppressionInputData.AllProjects);
    }
    
    [Fact]
    public void SuppressionsData_InitializeWithDefaultValues()
    {
        // Arrange & Act
        var suppressionsData = new SuppressionsData();

        // Assert
        Assert.Null(suppressionsData.ProjectId);
        Assert.Null(suppressionsData.Cause);
        Assert.Null(suppressionsData.Source);
        Assert.False(suppressionsData.Is_deletable);
        Assert.Equal(DateTime.MinValue, suppressionsData.Created);
        Assert.Equal(0, suppressionsData.Limit);
    }
    
    [Fact]
    public void SuppressionData_InitializeWithDefaultValues()
    {
        // Arrange & Act
        var suppressionData = new SuppressionData();

        // Assert
        Assert.Null(suppressionData.Status);
        Assert.Null(suppressionData.Email);
        Assert.Null(suppressionData.Cursor);
        Assert.Null(suppressionData.Suppressions);
    }
}