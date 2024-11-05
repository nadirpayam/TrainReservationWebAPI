using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainReservationWebAPI.Models;
using TrainReservationWebAPI.Services;

namespace TrainReservationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ReservationService _reservationService;

        public ReservationController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost("MakeReservation")]
        public IActionResult MakeReservation([FromBody] ReservationRequest request)
        {
            if (request == null)
            {
                return BadRequest("Reservation request is invalid.");
            }

            var result = _reservationService.MakeReservation(request);

            return Ok(result);
        }
    }
}
