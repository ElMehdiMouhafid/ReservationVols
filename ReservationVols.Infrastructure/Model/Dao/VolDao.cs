using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationVols.Infrastructure.Model.Dao
{
    /// <summary>
    /// the vol dao class.
    /// </summary>
    [Table("Vol")]
    public class VolDao
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public int Id { get; set; }

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
        public string DepartDate { get; set; }

        /// <summary>
        /// Gets or sets the arrival date.
        /// </summary>
        /// <value>
        /// The arrival date.
        /// </value>
        public string ArrivalDate { get; set; }

        /// <summary>
        /// Gets or sets the passengers numbre.
        /// </summary>
        /// <value>
        /// The passengers number.
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
