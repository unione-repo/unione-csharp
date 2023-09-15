namespace UniOneTests;

public class ErrorDataTests
{
    [Fact]
    public void ErrorData_ShouldHaveCorrectProperties()
    {
        // Arrange
        var errorDetailsData = ErrorDetailsData.CreateNew("errorStatus", "errorMessage", 500);

        // Act
        var errorData = new ErrorData
        {
            Status = "errorStatus",
            Details = errorDetailsData
        };

        // Assert
        Assert.Equal("errorStatus", errorData.Status);
        Assert.Equal(errorDetailsData, errorData.Details);
    }
    
    [Fact]
    public void CreateNew_ShouldReturnValidErrorDetailsData()
    {
        // Arrange

        // Act
        var errorDetailsData = ErrorDetailsData.CreateNew("errorStatus", "errorMessage", 500);

        // Assert
        Assert.Equal("errorStatus", errorDetailsData.Status);
        Assert.Equal("errorMessage", errorDetailsData.Message);
        Assert.Equal(500, errorDetailsData.Code);
    }
}