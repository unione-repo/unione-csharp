namespace UniOneTests;

public class ProjectDataTests
{
    [Fact]
    public void ProjectInputData_CreateNew_ReturnsValidInstance()
    {
        // Arrange
        string project_id = "project123";
        string project_api_key = "apikey123";
        string status = "active";

        // Act
        var projectInputData = ProjectInputData.CreateNew(project_id, project_api_key, status);

        // Assert
        Assert.NotNull(projectInputData);
        Assert.Equal(project_id, projectInputData.Project_Id);
        Assert.Equal(project_api_key, projectInputData.Project_api_key);
        Assert.Equal(status, projectInputData.Status);
    }
    
        [Fact]
    public void ProjectData_InitializeWithDefaultValues()
    {
        // Arrange & Act
        var projectData = new ProjectData();

        // Assert
        Assert.Null(projectData.Id);
        Assert.Null(projectData.Name);
        Assert.Null(projectData.Country);
        Assert.Equal(DateTime.MinValue, projectData.Reg_time);
        Assert.False(projectData.Send_enabled);
        Assert.False(projectData.Custom_unsubscribe_url_enabled);
        Assert.Equal(0, projectData.Backend_id);
    }

    [Fact]
    public void ProjectData_CreateNewWithAllParameters_ReturnsValidInstance()
    {
        // Arrange
        string id = "project123";
        string name = "Project Name";
        string country = "US";
        DateTime reg_time = DateTime.UtcNow;
        bool send_enabled = true;
        bool custom_unsubscribe_url_enabled = false;
        int backendId = 1;

        // Act
        var projectData = ProjectData.CreateNew(id, name, country, reg_time, send_enabled, custom_unsubscribe_url_enabled, backendId);

        // Assert
        Assert.NotNull(projectData);
        Assert.Equal(id, projectData.Id);
        Assert.Equal(name, projectData.Name);
        Assert.Equal(country, projectData.Country);
        Assert.Equal(reg_time, projectData.Reg_time);
        Assert.True(projectData.Send_enabled);
        Assert.False(projectData.Custom_unsubscribe_url_enabled);
        Assert.Equal(backendId, projectData.Backend_id);
    }

    [Fact]
    public void ProjectData_CreateNewWithMinimumParameters_ReturnsValidInstance()
    {
        // Arrange
        string name = "Project Name";
        string country = "US";
        bool send_enabled = true;
        bool custom_unsubscribe_url_enabled = false;
        int backendId = 1;

        // Act
        var projectData = ProjectData.CreateNew(name, country, send_enabled, custom_unsubscribe_url_enabled, backendId);

        // Assert
        Assert.NotNull(projectData);
        Assert.Equal("", projectData.Id); // Id should be empty string
        Assert.Equal(name, projectData.Name);
        Assert.Equal(country, projectData.Country);
        Assert.Equal(DateTime.Now.Date, projectData.Reg_time.Date); // Reg_time should be today's date
        Assert.True(projectData.Send_enabled);
        Assert.False(projectData.Custom_unsubscribe_url_enabled);
        Assert.Equal(backendId, projectData.Backend_id);
    }
}