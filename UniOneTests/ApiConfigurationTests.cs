using Allure.Xunit.Attributes;

namespace UniOneTests;

public class ApiConfigurationTests
{
    [AllureXunitTheory]
    [InlineData("https://example.com", "api", "v1", "apikey123",true,5)]
    [InlineData("https://api.example.com", "v2", "api", "apikey456",false,5)]
    public void CreateNew_ValidConfiguration_ShouldReturnValidApiConfiguration(string serverAddress, string apiUrl, string apiVersion, string apiKey,bool enableLogging, int timeout)
    {
        // Arrange

        // Act
        var apiConfig = ApiConfiguration.CreateNew(serverAddress, apiUrl, apiVersion, apiKey,enableLogging, timeout);

        // Assert
        Assert.Equal(serverAddress + "/", apiConfig.ServerAddress);
        Assert.Equal(apiUrl + "/", apiConfig.ApiUrl);
        Assert.Equal(apiVersion + "/", apiConfig.ApiVersion);
        Assert.Equal(apiKey, apiConfig.ApiKey);
    }

    [AllureXunitTheory]
    [InlineData("", "api", "v1", "apikey123",false,5)]
    [InlineData("https://example.com", "", "v1", "apikey456",false,5)]
    [InlineData("https://example.com", "api", "", "",false,5)]
    public void CreateNew_InvalidConfiguration_ShouldThrowEmptyApiConfigurationException(string serverAddress, string apiUrl, string apiVersion, string apiKey, bool enableLogging, int timeout)
    {
        // Arrange, Act & Assert
        Assert.Throws<EmptyApiConfigurationException>(() => ApiConfiguration.CreateNew(serverAddress, apiUrl, apiVersion, apiKey,enableLogging,timeout));
    }

    [AllureXunitTheory]
    [InlineData("https://example.com", "api", "v1")]
    [InlineData("https://api.example.com", "v2", "api")]
    [InlineData("https://api.example.com", "api/v2", "")]
    public void GetApiUrl_ShouldReturnValidApiUrl(string serverAddress, string apiUrl, string apiVersion)
    {
        // Arrange
        string expectedApiUrl = serverAddress + "/" + apiUrl + "/" + apiVersion + "/";
        var apiConfig = ApiConfiguration.CreateNew(serverAddress, apiUrl, apiVersion, "apikey123",false,5);

        // Act
        string actualApiUrl = apiConfig.GetApiUrl();

        // Assert
        Assert.Equal(expectedApiUrl, actualApiUrl);
    }
}