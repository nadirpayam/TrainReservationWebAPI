namespace TrainReservationWebAPI.Models
{
    public class ReservationResponse
    {
        public bool IsReservationPossible { get; set; }
        public List<SeatArrangement> Arrangements { get; set; }
    }
}
