using System;

namespace ReservationVols.Domain.Response
{
    public class VolResult
    {
        /// <summary>
        /// Gets or sets the vol identifier.
        /// </summary>
        /// <value>
        /// The vol identifier.
        /// </value>
        public int VolId { get; set; }

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
        public DateTime DepartDate { get; set; }

        /// <summary>
        /// Gets or sets the arrival date.
        /// </summary>
        /// <value>
        /// The arrival date.
        /// </value>
        public DateTime ArrivalDate { get; set; }

        /// <summary>
        /// Gets or sets the passengers NBR.
        /// </summary>
        /// <value>
        /// The passengers NBR.
        /// </value>
        public int PassengersNbr { get; set; }

        /// <summary>
        /// Gets or sets the vol price.
        /// </summary>
        /// <value>
        /// The vol price.
        /// </value>
        public double VolPrice { get; set; }

        /// <summary>
        /// Gets or sets the space available.
        /// </summary>
        /// <value>
        /// The space available.
        /// </value>
        public int SpaceAvailable { get; set; }
    }
}
