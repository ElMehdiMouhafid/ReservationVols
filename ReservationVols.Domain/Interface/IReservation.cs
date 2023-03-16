using ReservationVols.Domain.Request;
using System.Threading.Tasks;

namespace ReservationVols.Domain.Interface
{
    /// <summary>
    /// the reservation interface.
    /// </summary>
    public interface IReservation
    {
        /// <summary>
        /// Posts the reservation asynchronous.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>bool</returns>
        Task<bool> PostReservationAsync(ReservationRequest request);

        /// <summary>
        /// Gets the reservation asynchronous.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<bool> GetReservationAsync(ReservationRequest request);
    }
}
