global using LabDay3.Models.Domain;
global using LabDay3.Models.View;
global using LabDay3.Helpers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LabDay3.Controllers;
public class TicketController : Controller
{
    private readonly List<Ticket> _tickets = Ticket.GetTickets();
    public IActionResult Index()
    {
        return View(_tickets);
    }

    #region Add
    [HttpGet]
    public IActionResult Add()
    {
        GetFormData();
        return View();
    }


    [HttpPost]
    public IActionResult Add(AddTicketVM ticketVM)
    {
        var developrs = Developer.GetDevelopers();
        var selectedDevelopersIds = ticketVM.DevelopersIds;

        var selectedDevelopers = developrs
            .Where(d => selectedDevelopersIds.Contains(d.Id))
            .ToList();


        var newTicket = new Ticket
        {
            Id = Guid.NewGuid(),
            IsClosed = ticketVM.IsClosed,
            Severity = ticketVM.Severity,
            Description = ticketVM.Description,
            Department = Department.GetDepartments().First(d => d.Id == ticketVM.DepartmentId),
            Developers = selectedDevelopers
        };

        _tickets.Add(newTicket);
        return RedirectToAction(nameof(Index));
    }
    #endregion

    #region Edit


    [HttpGet]
    public IActionResult Edit(Guid id)
    {
        GetFormData();
        var ticketToEdit = _tickets.First(a => a.Id == id);
        var ticketVM = new EditTicketVM
        {
            Id = Guid.NewGuid(),
            IsClosed = ticketToEdit.IsClosed,
            Severity = ticketToEdit.Severity,
            Description = ticketToEdit.Description,
            DepartmentId = ticketToEdit.Department.Id,
            DevelopersIds = ticketToEdit.Developers.Select(d => d.Id).ToList()
        };

        return View(ticketVM);
    }

    [HttpPost]
    public IActionResult Edit(EditTicketVM tikcetVM)
    {
        var selectedDevelopers = GetDevelopersByIds(tikcetVM.DevelopersIds);

        var ticketToEdit = _tickets.First(t => t.Id == tikcetVM.Id);

        ticketToEdit.Id = tikcetVM.Id;
        ticketToEdit.IsClosed = ticketToEdit.IsClosed;
        ticketToEdit.Severity = ticketToEdit.Severity;
        ticketToEdit.Description = ticketToEdit.Description;
        ticketToEdit.Department = Department.GetDepartments().First(d => d.Id == tikcetVM.Id);
        ticketToEdit.Developers = selectedDevelopers;

        return RedirectToAction(nameof(Index));
    }
    #endregion

    #region Helpers
    private void GetFormData()
    {
        #region Departments

        var departments = Department.GetDepartments();
        var departmentList = departments.Select(d => new SelectListItem(d.Name, d.Id.ToString()));

        ViewData[MagicStrings.Departments] = departmentList;

        #endregion

        #region Developers

        var developers = Developer.GetDevelopers();
        var developersListItems = developers
            .Select(d => new SelectListItem($"{d.FirstName} {d.LastName}", d.Id.ToString()));
        ViewBag.developersListItems = developersListItems;

        #endregion
    }

    private static List<Developer> GetDevelopersByIds(List<Guid> selectedDevelopersIds)
    {
        var developers = Developer.GetDevelopers();
        var selectedDevelopers = developers
            .Where(a => selectedDevelopersIds.Contains(a.Id))
            .ToList();
        return selectedDevelopers;
    } 
    #endregion
}
