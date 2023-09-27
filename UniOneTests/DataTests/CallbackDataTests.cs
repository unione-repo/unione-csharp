namespace UniOneTests;

public class CallbackDataTests
{
    public class DeliveryInfoTests
    {
        [Fact]
        public void DeliveryInfo_ConstructedWithValues_HasCorrectProperties()
        {
            // Arrange
            string deliveryStatus = "Delivered";
            string destinationResponse = "OK";
            string userAgent = "Mozilla/5.0";
            string ip = "192.168.1.1";

            // Act
            var deliveryInfo = new DeliveryInfo
            {
                DeliveryStatus = deliveryStatus,
                DestinationResponse = destinationResponse,
                UserAgent = userAgent,
                Ip = ip
            };

            // Assert
            Assert.NotNull(deliveryInfo);
            Assert.Equal(deliveryStatus, deliveryInfo.DeliveryStatus);
            Assert.Equal(destinationResponse, deliveryInfo.DestinationResponse);
            Assert.Equal(userAgent, deliveryInfo.UserAgent);
            Assert.Equal(ip, deliveryInfo.Ip);
        }

        [Fact]
        public void DeliveryInfo_DefaultConstructor_HasDefaultProperties()
        {
            // Arrange & Act
            var deliveryInfo = new DeliveryInfo();

            // Assert
            Assert.NotNull(deliveryInfo);
            Assert.Null(deliveryInfo.DeliveryStatus);
            Assert.Null(deliveryInfo.DestinationResponse);
            Assert.Null(deliveryInfo.UserAgent);
            Assert.Null(deliveryInfo.Ip);
        }
    }
    
    public class EventDataTests
    {
        [Fact]
        public void EventData_ConstructedWithValues_HasCorrectProperties()
        {
            // Arrange
            
            string deliveryStatus = "Delivered";
            string destinationResponse = "OK";
            string userAgent = "Mozilla/5.0";
            string ip = "192.168.1.1";
            
            string jobId = "12345";
            var metadata = new Dictionary<string, string>
            {
                { "Key1", "Value1" },
                { "Key2", "Value2" }
            };
            string email = "test@example.com";
            string status = "Sent";
            string eventTime = "2023-08-17T12:00:00";
            string url = "https://example.com";
            var deliveryInfo = new DeliveryInfo
            {
                DeliveryStatus = deliveryStatus,
                DestinationResponse = destinationResponse,
                UserAgent = userAgent,
                Ip = ip
            };
            string blockTime = "2023-08-17T13:00:00";
            string blockType = "HardBounce";
            string domain = "example.com";
            int smtpBlocksCount = 2;
            string domainStatus = "Blocked";

            // Act
            var eventData = new EventData
            {
                JobId = jobId,
                Metadata = metadata,
                Email = email,
                Status = status,
                EventTime = eventTime,
                Url = url,
                DeliveryInfo = deliveryInfo,
                BlockTime = blockTime,
                BlockType = blockType,
                Domain = domain,
                SMTPBlocksCount = smtpBlocksCount,
                DomainStatus = domainStatus
            };

            // Assert
            Assert.NotNull(eventData);
            Assert.Equal(jobId, eventData.JobId);
            Assert.Equal(metadata, eventData.Metadata);
            Assert.Equal(email, eventData.Email);
            Assert.Equal(status, eventData.Status);
            Assert.Equal(eventTime, eventData.EventTime);
            Assert.Equal(url, eventData.Url);
            Assert.Equal(deliveryInfo, eventData.DeliveryInfo);
            Assert.Equal(blockTime, eventData.BlockTime);
            Assert.Equal(blockType, eventData.BlockType);
            Assert.Equal(domain, eventData.Domain);
            Assert.Equal(smtpBlocksCount, eventData.SMTPBlocksCount);
            Assert.Equal(domainStatus, eventData.DomainStatus);
        }
    }
    
    public class WebhookEventTests
    {
        [Fact]
        public void WebhookEvent_ConstructedWithValues_HasCorrectProperties()
        {
            // Arrange
            string deliveryStatus = "Delivered";
            string destinationResponse = "OK";
            string userAgent = "Mozilla/5.0";
            string ip = "192.168.1.1";
            
            string jobId = "12345";
            var metadata = new Dictionary<string, string>
            {
                { "Key1", "Value1" },
                { "Key2", "Value2" }
            };
            string email = "test@example.com";
            string status = "Sent";
            string eventTime = "2023-08-17T12:00:00";
            string url = "https://example.com";
            var deliveryInfo = new DeliveryInfo
            {
                DeliveryStatus = deliveryStatus,
                DestinationResponse = destinationResponse,
                UserAgent = userAgent,
                Ip = ip
            };
            string blockTime = "2023-08-17T13:00:00";
            string blockType = "HardBounce";
            string domain = "example.com";
            int smtpBlocksCount = 2;
            string domainStatus = "Blocked";
            string eventName = "EventOccurred";
            var eventData = new EventData
            {
                JobId = jobId,
                Metadata = metadata,
                Email = email,
                Status = status,
                EventTime = eventTime,
                Url = url,
                DeliveryInfo = deliveryInfo,
                BlockTime = blockTime,
                BlockType = blockType,
                Domain = domain,
                SMTPBlocksCount = smtpBlocksCount,
                DomainStatus = domainStatus
            };

            // Act
            var webhookEvent = new WebhookEvent
            {
                EventName = eventName,
                EventData = eventData
            };

            // Assert
            Assert.NotNull(webhookEvent);
            Assert.Equal(eventName, webhookEvent.EventName);
            Assert.Equal(eventData, webhookEvent.EventData);
        }
    }
    
    public class EventsByUserTests
    {
        [Fact]
        public void EventsByUser_ConstructedWithValues_HasCorrectProperties()
        {
            // Arrange
            string deliveryStatus = "Delivered";
            string destinationResponse = "OK";
            string userAgent = "Mozilla/5.0";
            string ip = "192.168.1.1";
            
            string jobId = "12345";
            var metadata = new Dictionary<string, string>
            {
                { "Key1", "Value1" },
                { "Key2", "Value2" }
            };
            string email = "test@example.com";
            string status = "Sent";
            string eventTime = "2023-08-17T12:00:00";
            string url = "https://example.com";
            var deliveryInfo = new DeliveryInfo
            {
                DeliveryStatus = deliveryStatus,
                DestinationResponse = destinationResponse,
                UserAgent = userAgent,
                Ip = ip
            };
            string blockTime = "2023-08-17T13:00:00";
            string blockType = "HardBounce";
            string domain = "example.com";
            int smtpBlocksCount = 2;
            string domainStatus = "Blocked";
            
            int userId = 1;
            string projectId = "project123";
            string projectName = "ProjectName";
            var events = new List<WebhookEvent>
            {
                new WebhookEvent
                {
                    EventName = "EventOccurred",
                    EventData = new EventData
                    {
                        JobId = jobId,
                        Metadata = metadata,
                        Email = email,
                        Status = status,
                        EventTime = eventTime,
                        Url = url,
                        DeliveryInfo = deliveryInfo,
                        BlockTime = blockTime,
                        BlockType = blockType,
                        Domain = domain,
                        SMTPBlocksCount = smtpBlocksCount,
                        DomainStatus = domainStatus
                    }
                }
            };

            // Act
            var eventsByUser = new EventsByUser
            {
                UserId = userId,
                ProjectId = projectId,
                ProjectName = projectName,
                Events = events
            };

            // Assert
            Assert.NotNull(eventsByUser);
            Assert.Equal(userId, eventsByUser.UserId);
            Assert.Equal(projectId, eventsByUser.ProjectId);
            Assert.Equal(projectName, eventsByUser.ProjectName);
            Assert.Equal(events, eventsByUser.Events);
        }
    }
    
    public class CallbackTests
    {
        [Fact]
        public void CallbackData_ConstructedWithValues_HasCorrectProperties()
        {
            // Arrange
            string deliveryStatus = "Delivered";
            string destinationResponse = "OK";
            string userAgent = "Mozilla/5.0";
            string ip = "192.168.1.1";
            
            string jobId = "12345";
            var metadata = new Dictionary<string, string>
            {
                { "Key1", "Value1" },
                { "Key2", "Value2" }
            };
            string email = "test@example.com";
            string status = "Sent";
            string eventTime = "2023-08-17T12:00:00";
            string url = "https://example.com";
            var deliveryInfo = new DeliveryInfo
            {
                DeliveryStatus = deliveryStatus,
                DestinationResponse = destinationResponse,
                UserAgent = userAgent,
                Ip = ip
            };
            string blockTime = "2023-08-17T13:00:00";
            string blockType = "HardBounce";
            string domain = "example.com";
            int smtpBlocksCount = 2;
            string domainStatus = "Blocked";
            
            string auth = "someAuth";
            var eventsByUser = new List<EventsByUser>
            {
                new EventsByUser
                {
                    UserId = 1,
                    ProjectId = "project123",
                    ProjectName = "ProjectName",
                    Events = new List<WebhookEvent>
                    {
                        new WebhookEvent
                        {
                            EventName = "EventOccurred",
                            EventData = new EventData
                            {
                                JobId = jobId,
                                Metadata = metadata,
                                Email = email,
                                Status = status,
                                EventTime = eventTime,
                                Url = url,
                                DeliveryInfo = deliveryInfo,
                                BlockTime = blockTime,
                                BlockType = blockType,
                                Domain = domain,
                                SMTPBlocksCount = smtpBlocksCount,
                                DomainStatus = domainStatus
                            }
                        }
                    }
                }
            };

            // Act
            var callbackData = new CallbackData
            {
                Auth = auth,
                EventsByUser = eventsByUser
            };

            // Assert
            Assert.NotNull(callbackData);
            Assert.Equal(auth, callbackData.Auth);
            Assert.Equal(eventsByUser, callbackData.EventsByUser);
        }
    }
}