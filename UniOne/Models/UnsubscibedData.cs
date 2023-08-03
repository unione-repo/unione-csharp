namespace UniOne.Models;

public class UnsubscibedData
{
    private string _emailAddress { get; set; }
    private DateTime _unsubscribedOn { get; set; }
    private bool _isUnsubscribed { get; set; }
    private string _message { get; set; }

    public string EmailAddress => _emailAddress;
    public DateTime UnsubscribedOn => _unsubscribedOn;
    public bool IsUnsubscribed => _isUnsubscribed;
    public string Message => _message;
    
    private UnsubscibedData(){}

    private UnsubscibedData(string emailAddress, DateTime unsubscribedOn, bool isUnsubscribed, string message)
    {
        _emailAddress = emailAddress;
        _unsubscribedOn = unsubscribedOn;
        _isUnsubscribed = isUnsubscribed;
        _message = message;
    }

    public static UnsubscibedData CreateNew(string emailAddress, DateTime unsubscribedOn, bool isUnsubscribed, string message)
    {
        return new UnsubscibedData(emailAddress, unsubscribedOn, isUnsubscribed, message);
    }
}