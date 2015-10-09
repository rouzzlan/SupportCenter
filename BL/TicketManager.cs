using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SC.BL.Domain;
using SC.DAL;
namespace SC.BL
{
  public class TicketManager : ITicketManager
  {
    private readonly ITicketRepository repo;
    public TicketManager()
    {
      repo = new TicketRepositoryHC();
    }

    public IEnumerable<Ticket> GetTickets()
    {
      return repo.ReadTickets();
    }
    public Ticket AddTicket(int accountId, string question)
    {
      Ticket t = new Ticket()
      {
        AccountId = accountId,
        Text = question,
        DateOpened = DateTime.Now,
        State = TicketState.Open,
      };
      return this.AddTicket(t);
    }
    public Ticket AddTicket(int accountId, string device, string problem)
    {
      Ticket t = new HardwareTicket()
      {
        AccountId = accountId,
        Text = problem,
        DateOpened = DateTime.Now,
        State = TicketState.Open,
        DeviceName = device
      };
      return this.AddTicket(t);
    }
    private Ticket AddTicket(Ticket ticket)
    {
      return repo.CreateTicket(ticket);
    }
    public Ticket GetTicket(int ticketNumber)
    {
      return repo.ReadTicket(ticketNumber);
    }
    public void ChangeTicket(Ticket ticket)
    {
      repo.UpdateTicket(ticket);
    }
    public void RemoveTicket(int ticketNumber)
    {
      repo.DeleteTicket(ticketNumber);
    }
    public IEnumerable<TicketResponse> GetTicketResponses(int ticketNumber)
    {
      return repo.ReadTicketResponsesOfTicket(ticketNumber);
    }
    public TicketResponse AddTicketResponse(int ticketNumber, string response, bool isClientResponse)
    {
      Ticket ticketToAddResponseTo = this.GetTicket(ticketNumber);
      if (ticketToAddResponseTo != null)
      {
        // Create response
        TicketResponse newTicketResponse = new TicketResponse();
        newTicketResponse.Date = DateTime.Now;
        newTicketResponse.Text = response;
        newTicketResponse.IsClientResponse = isClientResponse;
        newTicketResponse.Ticket = ticketToAddResponseTo;
        // Add response to ticket
        var responses = this.GetTicketResponses(ticketNumber);
        if (responses != null)
          ticketToAddResponseTo.Responses = responses.ToList();
        else
          ticketToAddResponseTo.Responses = new List<TicketResponse>();
        ticketToAddResponseTo.Responses.Add(newTicketResponse);
      if (isClientResponse)
          ticketToAddResponseTo.State = TicketState.ClientAnswer;
        else
          ticketToAddResponseTo.State = TicketState.Answered;
        // Save changes to repository
        repo.CreateTicketResponse(newTicketResponse);
        repo.UpdateTicket(ticketToAddResponseTo);
        return newTicketResponse;
      }
      else
        throw new ArgumentException("Ticketnumber '" + ticketNumber + "' not found!");
    }

  }
}
