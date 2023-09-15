using System.Text.Json.Serialization;

namespace UniOne.Models;

public class AccountingData
{
    /// <summary>
    /// Date and time of accounting period start in UTC in “YYYY-MM-DD hh:mm:ss” format.
    /// </summary>
    [JsonPropertyName("period_start")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime PeriodStart { get; set; }
    
    /// <summary>
    /// Date and time of accounting period end in UTC in “YYYY-MM-DD hh:mm:ss” format.
    /// </summary>
    [JsonPropertyName("period_end")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime PeriodEnd { get; set; }
    
    /// <summary>
    /// Number of emails included into accounting period.
    /// </summary>
    [JsonPropertyName("emails_included")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int EmailsIncluded { get; set; }
    
    /// <summary>
    /// Number of emails sent during accounting period. Can be bigger than emails_included in case of overage.
    /// </summary>
    [JsonPropertyName("emails_sent")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int EmailsSent { get; set; }

    public AccountingData()
    {
        
    }

    private AccountingData(DateTime periodStart, DateTime periodEnd, int emailsIncluded, int emailsSent)
    {
        PeriodStart = periodStart;
        PeriodEnd = periodEnd;
        EmailsIncluded = emailsIncluded;
        EmailsSent = emailsSent;
    }

    public static AccountingData CreateNew(DateTime periodStart, DateTime periodEnd, int emailsIncluded, int emailsSent)
    {
        return new AccountingData(periodStart, periodEnd, emailsIncluded, emailsSent);
    }
}