
using IssuesSystem.BL;
using IssuesSystem.BL.View;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;

namespace presentationLayer.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketManagers TicketsManager;
        

        public TicketsController(ITicketManagers ticketsManager)
        {
            TicketsManager = ticketsManager;
            
        }
        public IActionResult Index()
        {
            IEnumerable<ReadVM> AllTickets = TicketsManager.GetAll();
            return View(AllTickets);
        }
        public IActionResult Details(int id)
        {
            ReadVM? Ticket = TicketsManager.Get(id);
            return View(Ticket);
        }
        public IActionResult Delete(int id)
        {
            TicketsManager.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Add()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult Add(AddVM ticket)
        {
            TicketsManager.Add(ticket);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            UpdateVM? Ticket = TicketsManager.GetUpdate(id);
       
            return View(Ticket);
        }
        [HttpPost]
        public IActionResult Edit(UpdateVM ticket)
        {
            TicketsManager.Update(ticket);
            return RedirectToAction(nameof(Index));
        }
    }
}
