using ReservationVols.Domain.Request;
using ReservationVols.Domain.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservationVols.Domain.Interface
{
    /// <summary>
    /// the vol interface.
    /// </summary>
    public interface IVol
    {
        /// <summary>
        /// Gets the vols asynchronous.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>list of vols</returns>
        Task<IEnumerable<VolResult>> GetVolsAsync(VolRequest request);

        /// <summary>
        /// Updates the reservation asynchronous.
        /// </summary>
        /// <param name="volId">The vol identifier.</param>
        /// <returns></returns>
        Task<bool> UpdateSpaceAvailableVolAsync(int volId);
    }
}
