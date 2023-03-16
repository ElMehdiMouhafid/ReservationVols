using System.ComponentModel.DataAnnotations;

namespace ReservationVols.Domain.Request
{
    /// <summary>
    /// the reservation request class.
    /// </summary>
    public class ReservationRequest
    {
        /// <summary>
        /// Gets or sets the vol identifier.
        /// </summary>
        /// <value>
        /// The vol identifier.
        /// </value>
        [Required(ErrorMessage = "VolId is Required")]
        public int VolId { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [Required(ErrorMessage = "FirstName is Required")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [Required(ErrorMessage = "LastName is Required")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the mail.
        /// </summary>
        /// <value>
        /// The mail.
        /// </value>
        [Required(ErrorMessage = "Mail is Required")]
        public string Mail { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        [Required(ErrorMessage = "PhoneNumber is Required")]
        public string PhoneNumber { get; set; }
    }
}
