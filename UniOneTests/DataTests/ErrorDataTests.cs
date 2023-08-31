namespace UniOneTests;

public class ErrorDataTests
{
    [Fact]
    public void ErrorData_CreateNew_Returns_New_Instance()
    {
        // Arrange
        string status = "error";
        string message = "Test error message";
        int errorCode = 500;

        // Act
        var errorData = ErrorData.CreateNew(status, message, errorCode);

        // Assert
        Assert.NotNull(errorData);
        Assert.Equal(status, errorData.Status);
        Assert.Equal(message, errorData.Message);
        Assert.Equal(errorCode, errorData.Code);
    }

    [Fact]
    public void ErrorData_CreateNew_Handles_Null_Status()
    {
        // Arrange
        string status = null;
        string message = "Test error message";
        int errorCode = 500;

        // Act
        var errorData = ErrorData.CreateNew(status, message, errorCode);

        // Assert
        Assert.NotNull(errorData);
        Assert.Null(errorData.Status);
        Assert.Equal(message, errorData.Message);
        Assert.Equal(errorCode, errorData.Code);
    }
}