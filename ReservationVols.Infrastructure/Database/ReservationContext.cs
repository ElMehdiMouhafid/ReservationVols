using Microsoft.EntityFrameworkCore;
using ReservationVols.Infrastructure.Model.Dao;

namespace ReservationVols.Infrastructure.Database
{
    /// <summary>
    /// the reseravation context class.
    /// </summary>
    public class ReservationContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReservationContext" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public ReservationContext(DbContextOptions<ReservationContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the reservation DAO.
        /// </summary>
        /// <value>
        /// The reservation DAO.
        /// </value>
        public DbSet<ReservationDao> ReservationDao { get; set; }

        /// <summary>
        /// Gets or sets the vol DAO.
        /// </summary>
        /// <value>
        /// The vol DAO.
        /// </value>
        public DbSet<VolDao> VolDao { get; set; }
    }
}
