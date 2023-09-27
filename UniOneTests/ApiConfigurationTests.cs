namespace UniOneTests;

public class ApiConfigurationTests
{
    [Theory]
    [InlineData("https://example.com/", "api/", "v1/", "your-api-key", true, 30)]
    [InlineData("http://example.com/", "api/", "v1/", "your-api-key", false, 15)]
    public void CreateNew_ShouldCreateValidApiConfiguration(
        string serverAddress, string apiUrl, string apiVersion, string apiKey, bool enableLogging, int timeout)
    {
        // Act
        var apiConfig = ApiConfiguration.CreateNew(serverAddress, apiUrl, apiVersion, apiKey, enableLogging, timeout);

        // Assert
        Assert.NotNull(apiConfig);
        Assert.Equal(serverAddress, apiConfig.ServerAddress);
        Assert.Equal(apiUrl, apiConfig.ApiUrl);
        Assert.Equal(apiVersion, apiConfig.ApiVersion);
        Assert.Equal(apiKey, apiConfig.ApiKey);
        Assert.Equal(enableLogging, apiConfig.IsLoggingEnabled());
        Assert.Equal(timeout, apiConfig.GetTimeout());
    }

    [Theory]
    [InlineData("", "api/", "v1/", "your-api-key", true, 30)]
    [InlineData("https://example.com/", "", "v1/", "your-api-key", true, 30)]
    [InlineData("https://example.com/", "api", "v1/", "your-api-key", true, 30)]
    [InlineData("https://example.com/", "api/", "v1/", "", true, 30)]
    public void CreateNew_ShouldThrowEmptyApiConfigurationExceptionForInvalidInputs(
        string serverAddress, string apiUrl, string apiVersion, string apiKey, bool enableLogging, int timeout)
    {
        // Act & Assert
        Assert.Throws<EmptyApiConfigurationException>(() =>
        {
            ApiConfiguration.CreateNew(serverAddress, apiUrl, apiVersion, apiKey, enableLogging, timeout);
        });
    }
    [Fact]
    public void CreateNew_ShouldThrowEmptyApiConfigurationExceptionForMissingServerAddress()
    {
        // Arrange
        var serverAddress = "";
        var apiUrl = "api/";
        var apiVersion = "v1/";
        var apiKey = "your-api-key";
        var enableLogging = true;
        var timeout = 30;

        // Act & Assert
        Assert.Throws<EmptyApiConfigurationException>(() =>
        {
            ApiConfiguration.CreateNew(serverAddress, apiUrl, apiVersion, apiKey, enableLogging, timeout);
        });
    }

    [Fact]
    public void CreateNew_ShouldThrowEmptyApiConfigurationExceptionForMissingApiUrl()
    {
        // Arrange
        var serverAddress = "https://example.com/";
        var apiUrl = "";
        var apiVersion = "v1/";
        var apiKey = "your-api-key";
        var enableLogging = true;
        var timeout = 30;

        // Act & Assert
        Assert.Throws<EmptyApiConfigurationException>(() =>
        {
            ApiConfiguration.CreateNew(serverAddress, apiUrl, apiVersion, apiKey, enableLogging, timeout);
        });
    }

    [Fact]
    public void CreateNew_ShouldThrowEmptyApiConfigurationExceptionForInvalidApiUrl()
    {
        // Arrange
        var serverAddress = "https://example.com/";
        var apiUrl = "api"; // Missing trailing slash
        var apiVersion = "v1/";
        var apiKey = "your-api-key";
        var enableLogging = true;
        var timeout = 30;

        // Act & Assert
        Assert.Throws<EmptyApiConfigurationException>(() =>
        {
            ApiConfiguration.CreateNew(serverAddress, apiUrl, apiVersion, apiKey, enableLogging, timeout);
        });
    }

    [Fact]
    public void CreateNew_ShouldThrowEmptyApiConfigurationExceptionForMissingApiKey()
    {
        // Arrange
        var serverAddress = "https://example.com/";
        var apiUrl = "api/";
        var apiVersion = "v1/";
        var apiKey = "";
        var enableLogging = true;
        var timeout = 30;

        // Act & Assert
        Assert.Throws<EmptyApiConfigurationException>(() =>
        {
            ApiConfiguration.CreateNew(serverAddress, apiUrl, apiVersion, apiKey, enableLogging, timeout);
        });
    }

    [Theory]
    [InlineData("https://example.com/", "api/", "v1/", "your-api-key", true, 30)]
    [InlineData("http://example.com/", "api/", "v1/", "your-api-key", false, 15)]
    public void GetApiUrl_ShouldReturnFullLink(string serverAddress, string apiUrl, string apiVersion, string apiKey, bool enableLogging, int timeout)
    {
        // Act
        var apiConfig = ApiConfiguration.CreateNew(serverAddress, apiUrl, apiVersion, apiKey, enableLogging, timeout);
        
        Assert.Equal(serverAddress + apiUrl + apiVersion, apiConfig.GetApiUrl());
    }
}