using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReservationVols.Domain.Interface;
using ReservationVols.Domain.Request;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationVols.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VolController : ControllerBase
    {
        private readonly ILogger<VolController> _logger;
        private readonly IVol _vol;

        /// <summary>
        /// Initializes a new instance of the <see cref="VolController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="vol">The vol.</param>
        /// <exception cref="System.ArgumentNullException">
        /// logger
        /// or
        /// vol
        /// </exception>
        public VolController(ILogger<VolController> logger, IVol vol)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _vol = vol ?? throw new ArgumentNullException(nameof(vol));
        }

        /// <summary>
        /// Gets the vols asynchronous.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>A successful operation return a 200 http code.</returns>
        /// <response code="200">Success</response>
        /// <response code="404">NotFound</response>
        /// <response code="500">Server Error</response>
        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetVols([FromBody]VolRequest request)
        {
            try
            {
                var result = await _vol.GetVolsAsync(request).ConfigureAwait(false);
                if(result is null || !result.Any())
                { 
                    return NotFound(); 
                }

                return Ok(result);
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
