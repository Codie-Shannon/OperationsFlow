namespace OperationsFlow.Models;

public class TrainingRecord
{
    public int Id { get; set; }

    public string StaffName { get; set; } = "";
    public string TrainingName { get; set; } = "";

    public string Site { get; set; } = "";
    public string Department { get; set; } = "";

    public string Status { get; set; } = "";

    public DateTime CompletedDate { get; set; }
    public DateTime ExpiryDate { get; set; }

    public bool IsRequired { get; set; }

    public string Notes { get; set; } = "";

    public bool IsExpired => ExpiryDate.Date < DateTime.Today;
    public bool IsExpiringSoon => ExpiryDate.Date >= DateTime.Today && ExpiryDate.Date <= DateTime.Today.AddDays(30);
}