using HoPe.Core.Enums;

namespace HoPe.Core.Entities
{
    public class Reservation : BaseEntity
    {
        public Reservation(DateTime date, string comment, int idPet, string userCreated)
        {
            Date = date;
            Comment = comment;
            IdPet = idPet;
            UserCreated = userCreated;

            CreatedAt = DateTime.Now;
            Active = true;
            Status = ReservationStatusEnum.Created;
        }

        public DateTime Date { get; private set; }
        public string Comment { get; private set; }
        public string UserCreated { get; private set; }

        public int IdPet { get; private set; }
        public Pet Pet { get; private set; }
        public bool Active { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public ReservationStatusEnum Status { get; private set; }

        public void Cancel()
        {
            if (this.Status == ReservationStatusEnum.InProgress)
                this.Status = ReservationStatusEnum.Cancelled;
        }

        public void Finish()
        {
            if (this.Status == ReservationStatusEnum.InProgress)
            {
                this.Status = ReservationStatusEnum.Cancelled;
                this.FinishedAt = DateTime.Now;
            }
        }

        public void Start()
        {
            if (this.Status == ReservationStatusEnum.Created)
            {
                this.Status = ReservationStatusEnum.InProgress;
                this.StartedAt = DateTime.Now;
            }
        }

        public void Update(DateTime date, string comment)
        {
            this.Date = date;
            this.Comment = comment;
        }
    }
}
