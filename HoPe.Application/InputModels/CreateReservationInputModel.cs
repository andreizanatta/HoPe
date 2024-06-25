using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoPe.Application.InputModels
{
    public class CreateReservationInputModel
    {
        public int IdClient { get; set; }
        public DateTime Date { get; private set; }
        public string Comment { get; private set; }
        public string UserCreated { get; private set; }
    }
}
