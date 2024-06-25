using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoPe.Core.Entities
{
    public class Pet : BaseEntity
    {
        public Pet( string comment, string name)
        {
            Name = name;    
            Comment = comment;
            CreatedAt = DateTime.Now;
            Active = true;

            Reservations = new List<Reservation>();
        }

        public DateTime CreatedAt { get; private set; }
        public string Name { get; private set; }
        public string Comment { get; private set; }
        public bool Active { get; private set; }

        public List<Reservation> Reservations { get; set; }

        public void Disable()
        {
            this.Active = false;
        }

        public void Update(string name, string comment)
        {
            this.Name = name;
            this.Comment = comment;
        }
    }
}
