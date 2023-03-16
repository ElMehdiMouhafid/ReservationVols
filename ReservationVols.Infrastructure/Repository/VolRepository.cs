using Microsoft.EntityFrameworkCore;
using ReservationVols.Domain.Interface;
using ReservationVols.Domain.Request;
using ReservationVols.Domain.Response;
using ReservationVols.Infrastructure.Database;
using ReservationVols.Infrastructure.Extensions;
using ReservationVols.Infrastructure.Model.Assembler;
using ReservationVols.Infrastructure.Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ReservationVols.Infrastructure.Repository
{
    /// <summary>
    /// the vol repository class.
    /// </summary>
    public class VolRepository : IVol
    {
        private readonly ReservationContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="VolRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <exception cref="System.ArgumentNullException">dbContext</exception>
        public VolRepository(ReservationContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext)); ;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<VolResult>> GetVolsAsync(VolRequest request)
        {
            var deparDate = request.DepartDate.ToString("yyyy-MM-ddTHH:mm");
            var arrivalDate = request.ArrivalDate.ToString("yyyy-MM-ddTHH:mm");

            Expression<Func<VolDao, bool>> filter = v => (string.IsNullOrEmpty(request.DepartCity) || v.DepartCity.ToUpper().Equals(request.DepartCity.ToUpper()))
                && (string.IsNullOrEmpty(request.ArrivalCity) || v.ArrivalCity.ToUpper().Equals(request.ArrivalCity.ToUpper()))
                && (string.IsNullOrEmpty(deparDate) || v.DepartDate.Equals(deparDate))
                && (string.IsNullOrEmpty(arrivalDate) || v.ArrivalDate.Equals(arrivalDate))
                && (request.PassengersNbr == null || v.PassengersNbr == request.PassengersNbr);
            
            var volDaos = await _dbContext.VolDao.Where(filter).OrderBy(v => v.VolPrice).ToListAsync().ConfigureAwait(false);

            return volDaos.ToDomainVolList();
        }

        /// <inheritdoc/>
        public async Task<bool> UpdateSpaceAvailableVolAsync(int volId)
        {
            var volDao = _dbContext.VolDao.Where(v => v.Id == volId).FirstOrDefault();
            volDao.SpaceAvailable -= 1;
            var result = _dbContext.VolDao.Update(volDao);
            await _dbContext.SaveChangesAsync().ConfigureAwait(continueOnCapturedContext: false);
            return result.Entity != null;
        }
    }
}
