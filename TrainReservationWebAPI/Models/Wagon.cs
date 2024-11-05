namespace TrainReservationWebAPI.Models
{
    public class Wagon
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int OccupiedSeats { get; set; }
        public int AvailableSeats => (int)(Capacity * 0.7) - OccupiedSeats;
    }
}
