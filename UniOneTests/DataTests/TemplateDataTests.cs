using System.ComponentModel.DataAnnotations;

namespace UniOneTests;

public class TemplateDataTests
{
    [Fact]
    public void Body_ConstructedWithValues_HasCorrectProperties()
    {
        // Arrange
        string html = "<html><body>HTML content</body></html>";
        string plainText = "Plain text content";
        string amp = "<html><body>AMP content</body></html>";

        // Act
        var body = new Body
        {
            Html = html,
            PlainText = plainText,
            Amp = amp
        };

        // Assert
        Assert.NotNull(body);
        Assert.Equal(html, body.Html);
        Assert.Equal(plainText, body.PlainText);
        Assert.Equal(amp, body.Amp);
    }
    
    [Fact]
    public void Attachment_ConstructedWithValues_HasCorrectProperties()
    {
        // Arrange
        string type = "image/jpeg";
        string name = "attachment.jpg";
        string content = "base64encodedcontent";

        // Act
        var attachment = new Attachment
        {
            Type = type,
            Name = name,
            Content = content
        };

        // Assert
        Assert.NotNull(attachment);
        Assert.Equal(type, attachment.Type);
        Assert.Equal(name, attachment.Name);
        Assert.Equal(content, attachment.Content);
    }
    
    [Fact]
    public void InputData_CreateNew_ReturnsCorrectObject()
    {
        // Arrange
        string id = "input123";
        int? limit = 10;
        int? offset = 0;

        // Act
        var inputData = InputData.CreateNew(id, limit, offset);

        // Assert
        Assert.NotNull(inputData);
        Assert.Equal(id, inputData.Id);
        Assert.Equal(limit, inputData.Limit);
        Assert.Equal(offset, inputData.Offset);
    }

    [Fact]
    public void EditorType_HtmlValue_CorrectValue()
    {
        // Arrange & Act
        var htmlValue = EditorType.Html;

        // Assert
        Assert.Equal("html", htmlValue);
    }

    [Fact]
    public void EditorType_VisualValue_CorrectValue()
    {
        // Arrange & Act
        var visualValue = EditorType.Visual;

        // Assert
        Assert.Equal("visual", visualValue);
    }
    
    [Fact]
    public void TemplateEngine_NoneValue_CorrectValue()
    {
        // Arrange & Act
        var noneValue = TemplateEngine.None;

        // Assert
        Assert.Equal("none", noneValue);
    }

    [Fact]
    public void TemplateEngine_SimpleValue_CorrectValue()
    {
        // Arrange & Act
        var simpleValue = TemplateEngine.Simple;

        // Assert
        Assert.Equal("simple", simpleValue);
    }

    [Fact]
    public void TemplateEngine_VelocityValue_CorrectValue()
    {
        // Arrange & Act
        var velocityValue = TemplateEngine.Velocity;

        // Assert
        Assert.Equal("velocity", velocityValue);
    }
    
     [Fact]
        public void TemplateData_ConstructedWithValues_HasCorrectProperties()
        {
            // Arrange
            string id = "template123";
            string name = "Template Name";
            var editorType = EditorType.Html;
            var templateEngine = TemplateEngine.Simple;
            var globalSubstitutions = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "SubstitutionKey1", "SubstitutionValue1" },
                    { "SubstitutionKey2", "SubstitutionValue2" }
                }
            };
            var globalMetadata = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "MetadataKey1", "MetadataValue1" },
                    { "MetadataKey2", "MetadataValue2" }
                }
            };
            
            
            string html = "<html><body>HTML content</body></html>";
            string plainText = "Plain text content";
            string amp = "<html><body>AMP content</body></html>";

            // Act
            var body = new Body
            {
                Html = html,
                PlainText = plainText,
                Amp = amp
            };
            
            string subject = "Template Subject";
            string fromEmail = "sender@example.com";
            string fromName = "Sender Name";
            string replyTo = "replyto@example.com";
            int trackLinks = 1;
            int trackRead = 1;
            var headers = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "HeaderKey1", "HeaderValue1" },
                    { "HeaderKey2", "HeaderValue2" }
                }
            };
            
            string att_type = "image/jpeg";
            string att_name = "attachment.jpg";
            string att_content = "base64encodedcontent";

            string in_att_type = "image/jpeg";
            string in_att_name = "attachment.jpg";
            string in_att_content = "base64encodedcontent";
            // Act

            var attachments = new List<Attachment>
            {
                new Attachment
                {
                    Type = att_type,
                    Name = att_name,
                    Content = att_content
                }
            };
            var inlineAttachments = new List<Attachment>
            {
                new Attachment
                {
                    Type = in_att_type,
                    Name = in_att_name,
                    Content = in_att_content
                }
            };

            // Act
            var templateData = new TemplateData
            {
                Id = id,
                Name = name,
                EditorType = editorType,
                TemplateEngine = templateEngine,
                GlobalSubstitutions = globalSubstitutions,
                GlobalMetadata = globalMetadata,
                Body = body,
                Subject = subject,
                FromEmail = fromEmail,
                FromName = fromName,
                ReplyTo = replyTo,
                TrackLinks = trackLinks,
                TrackRead = trackRead,
                Headers = headers,
                Attachments = attachments,
                InlineAttachments = inlineAttachments
            };

            // Assert
            Assert.NotNull(templateData);
            Assert.Equal(id, templateData.Id);
            Assert.Equal(name, templateData.Name);
            Assert.Equal(editorType, templateData.EditorType);
            Assert.Equal(templateEngine, templateData.TemplateEngine);
            Assert.Equal(globalSubstitutions, templateData.GlobalSubstitutions);
            Assert.Equal(globalMetadata, templateData.GlobalMetadata);
            Assert.Equal(body, templateData.Body);
            Assert.Equal(subject, templateData.Subject);
            Assert.Equal(fromEmail, templateData.FromEmail);
            Assert.Equal(fromName, templateData.FromName);
            Assert.Equal(replyTo, templateData.ReplyTo);
            Assert.Equal(trackLinks, templateData.TrackLinks);
            Assert.Equal(trackRead, templateData.TrackRead);
            Assert.Equal(headers, templateData.Headers);
            Assert.Equal(attachments, templateData.Attachments);
            Assert.Equal(inlineAttachments, templateData.InlineAttachments);
        }

        [Fact]
        public void TemplateData_TrackLinksRangeAttribute_IsValid()
        {
            // Arrange
            var trackLinksProperty = typeof(TemplateData).GetProperty(nameof(TemplateData.TrackLinks));

            // Act
            var attributes = trackLinksProperty.GetCustomAttributes(typeof(RangeAttribute), true);
            var rangeAttribute = Assert.Single(attributes) as RangeAttribute;

            // Assert
            Assert.NotNull(rangeAttribute);
            Assert.Equal(0, rangeAttribute.Minimum);
            Assert.Equal(1, rangeAttribute.Maximum);
        }

        [Fact]
        public void TemplateData_TrackReadRangeAttribute_IsValid()
        {
            // Arrange
            var trackReadProperty = typeof(TemplateData).GetProperty(nameof(TemplateData.TrackRead));

            // Act
            var attributes = trackReadProperty.GetCustomAttributes(typeof(RangeAttribute), true);
            var rangeAttribute = Assert.Single(attributes) as RangeAttribute;

            // Assert
            Assert.NotNull(rangeAttribute);
            Assert.Equal(0, rangeAttribute.Minimum);
            Assert.Equal(1, rangeAttribute.Maximum);
        }
}

