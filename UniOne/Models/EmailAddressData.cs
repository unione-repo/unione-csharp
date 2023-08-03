namespace UniOne.Models;

public class EmailAddressData
{
    private string _address { get; set; }

    public string GetEmailAddress() => _address;
    
    private EmailAddressData(){}

    private EmailAddressData(string address)
    {
        _address = address;
    }

    public static EmailAddressData CreateNew(string emailAddress)
    {
        return new EmailAddressData(emailAddress);
    }
}