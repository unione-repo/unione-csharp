﻿namespace UniOneTests;

public class TagDataTests
{
    [Fact]
    public void CreateNew_ShouldReturnValidTagData()
    {
        // Arrange

        // Act
        var tagData = TagData.CreateNew(1, "ExampleTag");

        // Assert
        Assert.Equal(1, tagData.TagId);
        Assert.Equal("ExampleTag", tagData.Tag);
    }
}