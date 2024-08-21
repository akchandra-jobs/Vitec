using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a working_days_off entity with essential details
    /// </summary>
    [Table("WORKING_DAYS_OFF", Schema = "dbo")]
    public class WORKING_DAYS_OFF
    {
        /// <summary>
        /// Initializes a new instance of the WORKING_DAYS_OFF class.
        /// </summary>
        public WORKING_DAYS_OFF()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the WORKING_DAYS_OFF 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// NAME of the WORKING_DAYS_OFF 
        /// </summary>
        public string? NAME { get; set; }

        /// <summary>
        /// START_DATE of the WORKING_DAYS_OFF 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? START_DATE { get; set; }

        /// <summary>
        /// END_DATE of the WORKING_DAYS_OFF 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? END_DATE { get; set; }
        /// <summary>
        /// COUNTRY_CODE of the WORKING_DAYS_OFF 
        /// </summary>
        public string? COUNTRY_CODE { get; set; }
        /// <summary>
        /// EXPLANATORY_TEXT of the WORKING_DAYS_OFF 
        /// </summary>
        public string? EXPLANATORY_TEXT { get; set; }

        /// <summary>
        /// UPDATED_DATE of the WORKING_DAYS_OFF 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the WORKING_DAYS_OFF belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the WORKING_DAYS_OFF 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the WORKING_DAYS_OFF belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}