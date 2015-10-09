﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.BL.Domain
{
  public class Ticket
  {
    public int TicketNumber { get; set; }
    public int AccountId { get; set; }
    public string Text { get; set; }
    public DateTime DateOpened { get; set; }
    public TicketState State { get; set; }
    public ICollection<TicketResponse> Responses { get; set; }
  }
}
