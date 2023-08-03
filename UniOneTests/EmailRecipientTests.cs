namespace UniOneTests;

public class EmailRecipientTests
{
    [Theory]
        [InlineData("John Doe", "john.doe@example.com", "12345", "campaign123", "hash123", null)]
        [InlineData("Jane Smith", "jane.smith@example.com", "67890", "campaign456", "hash456", "Key1=Value1,Key2=Value2")]
        public void CreateRecipient_ValidInput_ShouldReturnValidRecipient(string name, string emailAddress, string customerId, string campaignId, string customerHash, string substitutions)
        {
            // Arrange

            // Convert the substitutions string to a Dictionary<string, string>
            Dictionary<string, string> substitutionsDict = ParseSubstitutions(substitutions);

            // Act
            var recipient = EmailRecipientData.CreateRecipient(name, emailAddress, customerId, campaignId, customerHash, substitutionsDict);

            // Assert
            Assert.Equal(name, recipient.Name);
            Assert.Equal(emailAddress, recipient.EmailAddress);
            Assert.Equal(customerId, recipient.CustomerId);
            Assert.Equal(campaignId, recipient.Campaign_Id);
            Assert.Equal(customerHash, recipient.CustomerHash);
            Assert.Equal(substitutionsDict, recipient.Substitutions);
        }

        [Theory]
        [InlineData("invalid.email")]
        [InlineData("invalid.email@")]
        [InlineData("@example.com")]
        public void CreateRecipient_InvalidEmailAddress_ShouldThrowIncorrectEmailAdressException(string invalidEmailAddress)
        {
            // Arrange

            // Act & Assert
            Assert.Throws<IncorrectEmailAdressException>(() => EmailRecipientData.CreateRecipient("Test Name", invalidEmailAddress, "12345", "campaign123", "hash123", null));
        }

        private Dictionary<string, string> ParseSubstitutions(string substitutions)
        {
            if (string.IsNullOrEmpty(substitutions))
                return null;

            var substitutionsDict = new Dictionary<string, string>();

            var keyValuePairs = substitutions.Split(',');

            foreach (var kvp in keyValuePairs)
            {
                var keyValue = kvp.Split('=');

                if (keyValue.Length == 2)
                {
                    substitutionsDict[keyValue[0]] = keyValue[1];
                }
            }

            return substitutionsDict;
        }
}