using IssuesSystem.BL.View;
using IssuesSystem.DAL;
using System.Net.Sockets;

namespace IssuesSystem.BL;

public class TicketsManager :ITicketManagers
{
    private readonly ITicketsRepo _ticketRepo;
	public TicketsManager(ITicketsRepo ticketsRepo)
	{
        this._ticketRepo = ticketsRepo;
	}

    public void Add(AddVM ticketVM)
    {
        var ticket = new Ticket
        {
            Title = ticketVM.title,
            Description = ticketVM.desc,
            Severity = ticketVM.sev

        };

        _ticketRepo.Add(ticket);
        _ticketRepo.SaveChanges();
    }

    public void Delete(int id)
    {
        _ticketRepo.Delete(id);
    }

    public ReadVM? Get(int id)
    {
        var ticketDB = _ticketRepo.Get(id);
        if (ticketDB == null)
        {
            return null;
        }
        return new ReadVM(ticketDB.Id , ticketDB.Description, ticketDB.Title, ticketDB.Severity.ToString(),ticketDB.Department!.Name,ticketDB.devolopers.Count() );
    }

    public List<ReadVM> GetAll()
    {
        var ticketDB = _ticketRepo.GetAll();
        return ticketDB.Select(d => new ReadVM(d.Id, d.Description, d.Title , d.Severity.ToString() , d.Department!.Name, d.devolopers.Count()))
            .ToList();
    }

    public int SaveChanges()
    {
        return _ticketRepo.SaveChanges();

    }

    public void Update(UpdateVM ticket)
    {
        var t = _ticketRepo.Get(ticket.id);
        t.Title = ticket.title;
        t.Description = ticket.desc;
        t.Severity = ticket.sev;

        _ticketRepo.SaveChanges();
    }

    public UpdateVM GetUpdate(int id)
    {
        var t = _ticketRepo.Get(id);
        var ticket = new UpdateVM(t.Id, t.Title, t.Description, t.Severity);
        return ticket;
    }
}
