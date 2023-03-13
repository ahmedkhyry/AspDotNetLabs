namespace LabDay2.Models.Domain;

public class Ticket
{
    public DateTime CreatedDate { get; set; }
    public bool IsClosed { get; set; }
    public Severity Severity { get; set; }
    public string? Description { get; set; }
    public Ticket() { }
    public Ticket(DateTime createdDate, bool isClosed, Severity severity, string desciption)
    {
        CreatedDate = createdDate;
        IsClosed = isClosed;
        Severity = severity;
        Description = desciption;
    }

    private static readonly List<Ticket> _tickets = new()
    {
        new(DateTime.Now.AddDays(-1), true, Severity.Low, "Abuse"),
        new(DateTime.Now.AddDays(-2), true, Severity.High, "Annoy"),
        new(DateTime.Now.AddDays(-3), true, Severity.High, "Upset"),
        new(DateTime.Now.AddDays(-4), true, Severity.Medium, "Sad"),
        new(DateTime.Now.AddDays(-5), true, Severity.Low, "Hate")
    };
                   
    public static List<Ticket> GetBooksList() => _tickets;
}
