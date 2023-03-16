using System;

namespace ReservationVols.Domain.Request
{
    /// <summary>
    /// the vol request class.
    /// </summary>
    public class VolRequest
    {
        /// <summary>
        /// Gets or sets the depart city.
        /// </summary>
        /// <value>
        /// The depart city.
        /// </value>
        public string DepartCity { get; set; }

        /// <summary>
        /// Gets or sets the arrival city.
        /// </summary>
        /// <value>
        /// The arrival city.
        /// </value>
        public string ArrivalCity { get; set; }

        /// <summary>
        /// Gets or sets the depart date.
        /// </summary>
        /// <value>
        /// The depart date.
        /// </value>
        public DateTime? DepartDate { get; set; }

        /// <summary>
        /// Gets or sets the arrival date.
        /// </summary>
        /// <value>
        /// The arrival date.
        /// </value>
        public DateTime? ArrivalDate { get; set; }

        /// <summary>
        /// Gets or sets the passengers NBR.
        /// </summary>
        /// <value>
        /// The passengers NBR.
        /// </value>
        public int? PassengersNbr { get; set; }
    }
}
