using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoPe.Application.ViewModels
{
    public class ReservationViewModel
    {
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public int IdClient { get; set; }
        public string UserCreated { get; set; }
    }
}
