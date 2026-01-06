namespace backend.Models;

public class SystemConfig
{
    public int Id { get; set; }

    // Bank Info
    public string BankName { get; set; } = "";
    public string BankCode { get; set; } = "";
    public string SwiftCode { get; set; } = "";
    public string Country { get; set; } = "";

    // Defaults
    public string BaseCurrency { get; set; } = "";
    public string DayCountConvention { get; set; } = "";
    public string FiscalYearStart { get; set; } = "";

    // Workflow
    public bool MakerChecker { get; set; }
    public bool FourEyes { get; set; }
    public bool AutoEscalation { get; set; }
    public int SlaHours { get; set; }

    // Notifications
    public bool EmailNotifications { get; set; }
    public bool ExpiryAlerts { get; set; }
    public int AlertDays { get; set; }
    public bool OverdueNotifications { get; set; }
}
