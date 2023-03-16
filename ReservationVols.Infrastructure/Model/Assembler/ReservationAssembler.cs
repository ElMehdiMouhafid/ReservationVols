using ReservationVols.Domain.Request;
using ReservationVols.Infrastructure.Model.Dao;

namespace ReservationVols.Infrastructure.Model.Assembler
{
    /// <summary>
    /// the reservation assembler class.
    /// </summary>
    public static class ReservationAssembler
    {
        /// <summary>
        /// Converts to reservationdao.
        /// </summary>
        /// <param name="reservation">The reservation.</param>
        /// <returns>reservation dao</returns>
        public static ReservationDao ToReservationDao(this ReservationRequest reservation)
            => reservation is null
                ? null
                : new ReservationDao
                {
                    VolId = reservation.VolId,
                    FirstName = reservation.FirstName,
                    LastName = reservation.LastName,
                    Mail = reservation.Mail,
                    PhoneNumber = reservation.PhoneNumber,
                };
    }
}
