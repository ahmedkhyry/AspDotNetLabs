global using LabDay2.Models.Domain;
global using LabDay2.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace LabDay2.Controllers;
public class TicketController : Controller
{
    private readonly List<Ticket> _tickets = Ticket.GetBooksList();
    public IActionResult Index() => View(_tickets);
    
    [HttpGet]
    public IActionResult Add() => View();

    [HttpPost]
    public IActionResult Add(TicketVM ticketVM)
    {
        var newTicket = new Ticket
        {
            CreatedDate = DateTime.Now,
            IsClosed = ticketVM.IsClosed,
            Severity = ticketVM.Severity,
            Description = ticketVM.Description,
        };
        _tickets.Add(newTicket);
        return RedirectToAction(nameof(Index));
    }
}
