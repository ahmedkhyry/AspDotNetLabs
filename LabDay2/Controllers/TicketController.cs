using LabDay2.Models.Domain;
using LabDay2.Models.View;
using Microsoft.AspNetCore.Mvc;
namespace LabDay2.Controllers;

public class TicketController : Controller
{
    private List<Ticket> _tickets = Ticket.GetBooksList();
    public IActionResult Index()
    {
        return View(_tickets);
    }
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

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
