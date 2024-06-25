using HoPe.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoPe.Application.InputModels
{
    public class UpdateReservationInputModel
    {
        public int Id { get; set; }
        public DateTime Date { get; private set; }
        public string Comment { get; private set; }
        public int IdClient { get; private set; }
    }
}
