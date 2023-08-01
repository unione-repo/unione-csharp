namespace UniOne.Models;

public class Accounting
{
    private DateTime _periodStart { get; set; }
    private DateTime _periodEnd { get; set; }
    private int _emailsIncluded { get; set; }
    private int _emailsSent { get; set; }

    public DateTime PeriodStart => _periodStart;
    public DateTime PeriodEnd => _periodEnd;
    public int EmailsIncluded => _emailsIncluded;
    public int EmailsSent => _emailsSent;

    public Accounting()
    {
        
    }

    private Accounting(DateTime periodStart, DateTime periodEnd, int emailsIncluded, int emailsSent)
    {
        _periodStart = periodStart;
        _periodEnd = periodEnd;
        _emailsIncluded = emailsIncluded;
        _emailsSent = emailsSent;
    }

    public Accounting CreateNew(DateTime periodStart, DateTime periodEnd, int emailsIncluded, int emailsSent)
    {
        return new Accounting(periodStart, periodEnd, emailsIncluded, emailsSent);
    }
}