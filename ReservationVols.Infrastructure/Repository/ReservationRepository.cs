using Microsoft.EntityFrameworkCore;
using ReservationVols.Domain.Interface;
using ReservationVols.Domain.Request;
using ReservationVols.Infrastructure.Database;
using ReservationVols.Infrastructure.Model.Assembler;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationVols.Infrastructure.Repository
{
    /// <summary>
    /// the reservation repository class.
    /// </summary>
    public class ReservationRepository : IReservation
    {
        private readonly ReservationContext _dbContext;
        private readonly IVol _volRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReservationRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <exception cref="System.ArgumentNullException">dbContext</exception>
        public ReservationRepository(ReservationContext dbContext, IVol volRepository) 
        {  
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _volRepository = volRepository ?? throw new ArgumentNullException(nameof(volRepository));
        }

        /// <inheritdoc/>
        public async Task<bool> PostReservationAsync(ReservationRequest request)
        {
            var result = await _dbContext.ReservationDao.AddAsync(request.ToReservationDao()).ConfigureAwait(false);
            var updateVol = await _volRepository.UpdateSpaceAvailableVolAsync(request.VolId).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(continueOnCapturedContext: false);
            return result.Entity != null && updateVol;
        }

        /// <inheritdoc/>
        public async Task<bool> GetReservationAsync(ReservationRequest request)
        {
            var reservationDaos = await _dbContext.ReservationDao
                .Where(r => r.VolId == request.VolId
                        && r.FirstName.ToUpper().Equals(request.FirstName.ToUpper())
                        && r.LastName.ToUpper().Equals(request.LastName.ToUpper())
                        && r.Mail.ToUpper().Equals(request.Mail.ToUpper())
                        && r.PhoneNumber.Equals(request.PhoneNumber)).FirstOrDefaultAsync().ConfigureAwait(false);
            
            return reservationDaos != null;
        }
    }
}
