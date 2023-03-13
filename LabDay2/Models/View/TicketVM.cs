global using LabDay2.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace LabDay2.Models.View;

public record TicketVM
{
    public string? Description { get; init; }
    [Display(Name = "Is Closed")]
    public bool IsClosed { get; init; }
    public Severity Severity { get; init; }
}
