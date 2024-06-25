using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoPe.Core.Enums
{
    public enum ReservationStatusEnum
    {
        Created = 0,
        InProgress = 1,
        Suspended = 2,
        Cancelled = 3,
        Finished = 4,
    }
}
