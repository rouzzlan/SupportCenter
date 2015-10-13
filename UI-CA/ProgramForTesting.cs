using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SC.BL.Domain;
using System.ComponentModel.DataAnnotations;

namespace SC.UI.CA
{
  class ProgramForTesting
  {
    public static void Main(string[] args)
    {
      Ticket t2 = new HardwareTicket() { TicketNumber = 2, AccountId = 1, DeviceName = "LPT-9876", Text = "text", State = TicketState.Open, DateOpened = DateTime.Now }; var errors = new List<ValidationResult>(); Validator.TryValidateObject(t2, new ValidationContext(t2), errors, validateAllProperties: true);
    
  }
  }
}
