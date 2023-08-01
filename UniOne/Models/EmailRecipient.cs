using System.Text.RegularExpressions;
using UniOne.Exceptions;

namespace UniOne.Models;

public class EmailRecipient
{
    private string? _name { get; set; }
    private string _emailAddress { get; set; }
    private string _customerId { get; set; }
    private string _campaign_id { get; set; }
    private string _customer_hash { get; set; }
    private object? _substitutions { get; set; }


    public string? Name => _name;
    public string EmailAddress => _emailAddress;
    public string CustomerId => _customerId;
    public string CustomerHash => _customer_hash;
    public string Campaign_Id => _campaign_id;
    public object Substitutions => _substitutions;
    
    public EmailRecipient()
    {
    }

    private EmailRecipient(string name, string emailAddress, string customerId, string campaignId, string customerHash, object substitutions)
    {
        _name = name;
        _emailAddress = emailAddress;
        _customerId = customerId;
        _customer_hash = customerHash;
        _campaign_id = campaignId;
        _substitutions = substitutions;
    }

    public static EmailRecipient CreateRecipient(string name, string emailAddress, string customerId, string campaignId, string customerHash, object substitutions)
    {
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        Match match = regex.Match(emailAddress);

        if (match.Success)
            return new EmailRecipient(name, emailAddress, customerId, campaignId, customerHash,substitutions);
        else
            throw new IncorrectEmailAdressException(emailAddress + " is not valid email address!");
    }
}