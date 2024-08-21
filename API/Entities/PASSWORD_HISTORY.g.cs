using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a password_history entity with essential details
    /// </summary>
    [Table("PASSWORD_HISTORY", Schema = "dbo")]
    public class PASSWORD_HISTORY
    {
        /// <summary>
        /// Initializes a new instance of the PASSWORD_HISTORY class.
        /// </summary>
        public PASSWORD_HISTORY()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the PASSWORD_HISTORY 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PASSWORD_HISTORY belongs 
        /// </summary>
        public Guid? GUID_USER { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER")]
        public USR? GUID_USER_USR { get; set; }
        /// <summary>
        /// PASSWORD of the PASSWORD_HISTORY 
        /// </summary>
        public string? PASSWORD { get; set; }

        /// <summary>
        /// SET_DATE of the PASSWORD_HISTORY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? SET_DATE { get; set; }

        /// <summary>
        /// EXPIRED_DATE of the PASSWORD_HISTORY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? EXPIRED_DATE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the PASSWORD_HISTORY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PASSWORD_HISTORY belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the PASSWORD_HISTORY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PASSWORD_HISTORY belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}