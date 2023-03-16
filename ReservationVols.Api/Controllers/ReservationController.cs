using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReservationVols.Domain.Interface;
using ReservationVols.Domain.Request;
using System;
using System.Threading.Tasks;

namespace ReservationVols.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly ILogger<ReservationController> _logger;
        private readonly IReservation _reservation;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReservationController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="reservation">The reservation.</param>
        /// <exception cref="System.ArgumentNullException">
        /// logger
        /// or
        /// reservation
        /// </exception>
        public ReservationController(ILogger<ReservationController> logger, IReservation reservation)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _reservation = reservation ?? throw new ArgumentNullException(nameof(reservation));
        }

        /// <summary>
        /// Posts the reservation asynchronous.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>A successful operation return a 200 http code.</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Server Error</response>
        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostReservationAsync([FromBody]ReservationRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var reservationExist = await _reservation.GetReservationAsync(request).ConfigureAwait(false);

                if (reservationExist) { return BadRequest(Constants.RESERVATION_EXIT); }

                var result = await _reservation.PostReservationAsync(request).ConfigureAwait(false);
                return Ok(Constants.RESERVATION_REGISTERED);
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
