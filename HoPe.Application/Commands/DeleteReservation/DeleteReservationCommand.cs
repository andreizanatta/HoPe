using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoPe.Application.Commands.DeleteReservation
{
    public class DeleteReservationCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
