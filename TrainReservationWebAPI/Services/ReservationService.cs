using TrainReservationWebAPI.Models;

namespace TrainReservationWebAPI.Services
{
    public class ReservationService
    {
        public ReservationResponse MakeReservation(ReservationRequest request)
        {
            var response = new ReservationResponse
            {
                IsReservationPossible = false,
                Arrangements = new List<SeatArrangement>()
            };

            int remainingPeople = request.ReservationPersonCount;

            if (!request.AllowDifferentWagons)
            {
                var suitableWagon = request.Train.Wagons.FirstOrDefault(
                    w => w.AvailableSeats >= remainingPeople
                );

                if (suitableWagon != null)
                {
                    response.IsReservationPossible = true;
                    response.Arrangements.Add(new SeatArrangement
                    {
                        WagonName = suitableWagon.Name,
                        PersonCount = remainingPeople
                    });
                }

                return response;
            }

            foreach (var wagon in request.Train.Wagons)
            {
                if (wagon.AvailableSeats <= 0)
                    continue;

                int peopleInThisWagon = Math.Min(remainingPeople, wagon.AvailableSeats);
                remainingPeople -= peopleInThisWagon;

                response.Arrangements.Add(new SeatArrangement
                {
                    WagonName = wagon.Name,
                    PersonCount = peopleInThisWagon
                });

                if (remainingPeople <= 0)
                    break;
            }

            response.IsReservationPossible = remainingPeople == 0;
            if (!response.IsReservationPossible)
            {
                response.Arrangements.Clear();
            }

            return response;
        }
    }
}
