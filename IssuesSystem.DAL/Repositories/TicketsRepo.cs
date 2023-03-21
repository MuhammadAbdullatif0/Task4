using Microsoft.EntityFrameworkCore;

namespace IssuesSystem.DAL;

public class TicketsRepo : ITicketsRepo
{
    private readonly IssuesContext _context;

    public TicketsRepo(IssuesContext context)
    {
        _context = context;
    }

    public IEnumerable<Ticket> GetAll()
    {

        return _context.Set<Ticket>().Include(t=>t.Department).Include(t=>t.devolopers);
    }

    public Ticket? Get(int id)
    {
        return _context.Set<Ticket>().Find(id);
    }

    public void Add(Ticket ticket)
    {
        _context.Set<Ticket>().Add(ticket);
    }

    public void Update(Ticket ticket)
    {
    }

    public void Delete(int id)
    {
        var ticketToDelete = Get(id);
        if (ticketToDelete != null)
        {
            _context.Set<Ticket>().Remove(ticketToDelete);
            SaveChanges();
        }
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}