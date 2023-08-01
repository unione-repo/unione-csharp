namespace UniOneTests;

public class ApiConfigurationTests
{
    [Theory]
    [InlineData("https://example.com", "api", "v1", "apikey123")]
    [InlineData("https://api.example.com", "v2", "api", "apikey456")]
    public void CreateNew_ValidConfiguration_ShouldReturnValidApiConfiguration(string serverAddress, string apiUrl, string apiVersion, string apiKey)
    {
        // Arrange

        // Act
        var apiConfig = ApiConfiguration.CreateNew(serverAddress, apiUrl, apiVersion, apiKey);

        // Assert
        Assert.Equal(serverAddress + "/", apiConfig.ServerAddress);
        Assert.Equal(apiUrl + "/", apiConfig.ApiUrl);
        Assert.Equal(apiVersion + "/", apiConfig.ApiVersion);
        Assert.Equal(apiKey, apiConfig.ApiKey);
    }

    [Theory]
    [InlineData("", "api", "v1", "apikey123")]
    [InlineData("https://example.com", "", "v1", "apikey456")]
    [InlineData("https://example.com", "api", "", "")]
    public void CreateNew_InvalidConfiguration_ShouldThrowEmptyApiConfigurationException(string serverAddress, string apiUrl, string apiVersion, string apiKey)
    {
        // Arrange, Act & Assert
        Assert.Throws<EmptyApiConfigurationException>(() => ApiConfiguration.CreateNew(serverAddress, apiUrl, apiVersion, apiKey));
    }

    [Theory]
    [InlineData("https://example.com", "api", "v1")]
    [InlineData("https://api.example.com", "v2", "api")]
    [InlineData("https://api.example.com", "api/v2", "")]
    public void GetApiUrl_ShouldReturnValidApiUrl(string serverAddress, string apiUrl, string apiVersion)
    {
        // Arrange
        string expectedApiUrl = serverAddress + "/" + apiUrl + "/" + apiVersion + "/";
        var apiConfig = ApiConfiguration.CreateNew(serverAddress, apiUrl, apiVersion, "apikey123");

        // Act
        string actualApiUrl = apiConfig.GetApiUrl();

        // Assert
        Assert.Equal(expectedApiUrl, actualApiUrl);
    }
}