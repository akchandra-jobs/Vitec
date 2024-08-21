using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a log_security entity with essential details
    /// </summary>
    [Table("LOG_SECURITY", Schema = "dbo")]
    public class LOG_SECURITY
    {
        /// <summary>
        /// Initializes a new instance of the LOG_SECURITY class.
        /// </summary>
        public LOG_SECURITY()
        {
            SEVERITY = -1;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field SEVERITY of the LOG_SECURITY 
        /// </summary>
        [Required]
        public int SEVERITY { get; set; }

        /// <summary>
        /// Primary key for the LOG_SECURITY 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// USERNAME of the LOG_SECURITY 
        /// </summary>
        public string? USERNAME { get; set; }
        /// <summary>
        /// REASON of the LOG_SECURITY 
        /// </summary>
        public string? REASON { get; set; }
        /// <summary>
        /// URL of the LOG_SECURITY 
        /// </summary>
        public string? URL { get; set; }
        /// <summary>
        /// ACTION_TYPE of the LOG_SECURITY 
        /// </summary>
        public string? ACTION_TYPE { get; set; }
        /// <summary>
        /// USER_ENVIRONMENT of the LOG_SECURITY 
        /// </summary>
        public string? USER_ENVIRONMENT { get; set; }
        /// <summary>
        /// USER_IP of the LOG_SECURITY 
        /// </summary>
        public string? USER_IP { get; set; }

        /// <summary>
        /// CREATION_DATE of the LOG_SECURITY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the LOG_SECURITY belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}