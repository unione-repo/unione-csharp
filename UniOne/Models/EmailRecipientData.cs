using System.Text.RegularExpressions;
using Newtonsoft.Json;
using UniOne.Exceptions;

namespace UniOne.Models;

public class EmailRecipientData
{
    /// <summary>
    /// Recipient email
    /// </summary>
    [JsonProperty("name")]
    public string? Name { get; set; }
    [JsonProperty("email")]
    public string EmailAddress { get; set; }
    public string CustomerId { get; set; }
    [JsonProperty("campaign_id")]
    public string Campaign_id { get; set; }
    [JsonProperty("customer_hash")]
    public string Customer_hash { get; set; }
    
    /// <summary>
    /// Object to pass the substitutions(merge tags) for the recipient (e.g. recipient name, discount code, password change link, etc. See Template engines). The substitutions can be used in the following parameters:
    ///    body.html
    ///    body.plaintext
    ///    body.amp
    ///    subject
    ///    from_name
    ///    headers[“List-Unsubscribe”]
    ///    options.unsubscribe_url
    ///
    /// A substitution name can consist from latin characters, numbers and “_” symbol, and should start with the letter. There’s a special substitution “to_name” which is used to put recipent’s name like “Name Surname” to include it to SMTP header “To” in the form “Name Surname <email@example.com>”. The “to_name” length is limited to 78 symbols.
    /// </summary>
    [JsonProperty("substitutions")]
    public object? Substitutions { get; set; }
    
    public EmailRecipientData()
    {
    }

    private EmailRecipientData(string name, string emailAddress, string customerId, string campaignId, string customerHash, object substitutions)
    {
        Name = name;
        EmailAddress = emailAddress;
        CustomerId = customerId;
        Customer_hash = customerHash;
        Campaign_id = campaignId;
        Substitutions = substitutions;
    }

    public static EmailRecipientData CreateRecipient(string name, string emailAddress, string customerId, string campaignId, string customerHash, object substitutions)
    {
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        Match match = regex.Match(emailAddress);

        if (match.Success)
            return new EmailRecipientData(name, emailAddress, customerId, campaignId, customerHash,substitutions);
        else
            throw new IncorrectEmailAdressException(emailAddress + " is not valid email address!");
    }
}