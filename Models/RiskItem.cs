namespace OperationsFlow.Models;

public class RiskItem
{
    public int Id { get; set; }

    public string Title { get; set; } = "";
    public string Hazard { get; set; } = "";

    public string Site { get; set; } = "";
    public string Department { get; set; } = "";
    public string Owner { get; set; } = "";

    public int Likelihood { get; set; }
    public int Consequence { get; set; }

    public string Controls { get; set; } = "";
    public string Status { get; set; } = "";

    public DateTime ReviewDate { get; set; }

    public int RiskScore => Likelihood * Consequence;

    public string RiskLevel
    {
        get
        {
            if (RiskScore >= 16) return "Critical";
            if (RiskScore >= 10) return "High";
            if (RiskScore >= 5) return "Medium";
            return "Low";
        }
    }

    public bool IsReviewOverdue => ReviewDate.Date < DateTime.Today;
}