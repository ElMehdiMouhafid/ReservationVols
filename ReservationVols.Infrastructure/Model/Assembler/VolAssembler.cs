using ReservationVols.Domain.Response;
using ReservationVols.Infrastructure.Extensions;
using ReservationVols.Infrastructure.Model.Dao;
using System.Collections.Generic;
using System.Linq;

namespace ReservationVols.Infrastructure.Model.Assembler
{
    /// <summary>
    /// the vol assembler class.
    /// </summary>
    public static class VolAssembler
    {
        /// <summary>
        /// Converts to domainvollist.
        /// </summary>
        /// <param name="volDaos">The vol daos.</param>
        /// <returns>list of vols result</returns>
        public static IEnumerable<VolResult> ToDomainVolList(this IEnumerable<VolDao> volDaos)
        {
            if (volDaos == null || !volDaos.Any())
            {
                return new List<VolResult>();
            }

            return volDaos.ToList().ConvertAll(ToDomainVol);
        }

        /// <summary>
        /// Converts to domainvol.
        /// </summary>
        /// <param name="volDao">The vol DAO.</param>
        /// <returns>vol result</returns>
        public static VolResult ToDomainVol(this VolDao volDao)
            => volDao is null
                ? null
                : new VolResult
                {
                    VolId = volDao.Id,
                    ArrivalCity = volDao.ArrivalCity,
                    ArrivalDate = volDao.ArrivalDate.ToDateTime(),
                    DepartCity = volDao.DepartCity,
                    DepartDate = volDao.DepartDate.ToDateTime(),
                    PassengersNbr = volDao.PassengersNbr,
                    VolPrice = volDao.VolPrice,
                    SpaceAvailable = volDao.SpaceAvailable,
                };
    }
}

