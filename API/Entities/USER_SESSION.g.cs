using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a user_session entity with essential details
    /// </summary>
    [Table("USER_SESSION", Schema = "dbo")]
    public class USER_SESSION
    {
        /// <summary>
        /// Initializes a new instance of the USER_SESSION class.
        /// </summary>
        public USER_SESSION()
        {
            IS_ACTIVE = false;
            IS_TERMINATED = false;
            NUMBER_OF_INTERRUPTIONS = 0;
            CREATION_DATE = DateTime.UtcNow;
            UPDATED_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the USER_SESSION 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field IS_ACTIVE of the USER_SESSION 
        /// </summary>
        [Required]
        public bool IS_ACTIVE { get; set; }

        /// <summary>
        /// Required field IS_TERMINATED of the USER_SESSION 
        /// </summary>
        [Required]
        public bool IS_TERMINATED { get; set; }

        /// <summary>
        /// Required field NUMBER_OF_INTERRUPTIONS of the USER_SESSION 
        /// </summary>
        [Required]
        public int NUMBER_OF_INTERRUPTIONS { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the USER_SESSION belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the USER_SESSION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the USER_SESSION belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// WINDOWS_USER_NAME of the USER_SESSION 
        /// </summary>
        public string? WINDOWS_USER_NAME { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the USER_SESSION belongs 
        /// </summary>
        public Guid? GUID_USER { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER")]
        public USR? GUID_USER_USR { get; set; }
        /// <summary>
        /// ID of the USER_SESSION 
        /// </summary>
        public string? ID { get; set; }

        /// <summary>
        /// LOGIN_DATE of the USER_SESSION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? LOGIN_DATE { get; set; }

        /// <summary>
        /// LOGOUT_DATE of the USER_SESSION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? LOGOUT_DATE { get; set; }

        /// <summary>
        /// ALIVE_SIGNAL_DATE of the USER_SESSION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ALIVE_SIGNAL_DATE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the USER_SESSION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
    }
}