using IssuesSystem.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace IssuesSystem.DAL;

public class Ticket
{
	public int Id { get; set; }

	[Required]
	public string Title { get; set; } = string.Empty;

	[Required]
	public string Description { get; set; } = string.Empty;

	public Severity Severity { get; set; }
	public int DepartmentId { get; set; }

    public Department? Department { get; set; }
    public ICollection<Devoloper> devolopers { get; set; } = new HashSet<Devoloper>();

}
