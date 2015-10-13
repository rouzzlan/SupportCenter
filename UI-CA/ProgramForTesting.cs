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
      Ticket t1 = new Ticket() {
        TicketNumber = 1, AccountId = 1, Text = "", State = TicketState.Open, DateOpened = DateTime.Now
      };
      var errors = new List<ValidationResult>();
      Validator.TryValidateObject(t1, new ValidationContext(t1), errors, validateAllProperties: true);
    }
  }
}
