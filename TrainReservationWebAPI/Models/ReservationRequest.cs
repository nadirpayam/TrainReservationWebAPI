using System.Diagnostics;

namespace TrainReservationWebAPI.Models
{
    public class ReservationRequest
    {
        public Train Train { get; set; }
        public int ReservationPersonCount { get; set; }
        public bool AllowDifferentWagons { get; set; }
    }
}
