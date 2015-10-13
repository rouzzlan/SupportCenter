using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SC.BL.Domain
{
  public class TicketResponse
  {
    public int Id { get; set; }
    [Required]
    public string Text { get; set; }
    public DateTime Date { get; set; }
    public bool IsClientResponse { get; set; }
    [Required]
    public Ticket Ticket { get; set; }
  }
}