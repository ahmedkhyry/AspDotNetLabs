using System.ComponentModel.DataAnnotations;

namespace LabDay3.Models.View;

public record AddTicketVM
{
    public string Description { get; set; } = string.Empty;
    [Display(Name = "Is Closed")]
    public bool IsClosed { get; init; }
    public Severity Severity { get; init; }
    [Display(Name = "Department")]
    public Guid DepartmentId { get; set; }
    [Display(Name = "Developers")]
    public List<Guid> DevelopersIds { get; set; } = new();
}
