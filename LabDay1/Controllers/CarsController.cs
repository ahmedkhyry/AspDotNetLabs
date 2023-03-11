using LabDay1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LabDay1.Controllers;
//public enum Source
//{
//    list,
//    table
//}
public class CarsController : Controller
{
    public IActionResult GetAll()
    {
        var cars = CarModel.GetCars();
        return View(cars);
    }
    public IActionResult GetDetails(string? manufacturer, string? source)
    {
        var car = CarModel.GetCars().FirstOrDefault(c => c.Manufacturer == manufacturer);
        var carSource = new { car, source };
        return View(carSource);
    }
}
