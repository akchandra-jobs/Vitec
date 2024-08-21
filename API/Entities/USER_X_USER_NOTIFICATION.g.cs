using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a user_x_user_notification entity with essential details
    /// </summary>
    [Table("USER_X_USER_NOTIFICATION", Schema = "dbo")]
    public class USER_X_USER_NOTIFICATION
    {
        /// <summary>
        /// Initializes a new instance of the USER_X_USER_NOTIFICATION class.
        /// </summary>
        public USER_X_USER_NOTIFICATION()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the USER_X_USER_NOTIFICATION 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the USER_X_USER_NOTIFICATION belongs 
        /// </summary>
        public Guid? GUID_USER { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER")]
        public USR? GUID_USER_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the USER_NOTIFICATION to which the USER_X_USER_NOTIFICATION belongs 
        /// </summary>
        public Guid? GUID_USER_NOTIFICATION { get; set; }

        /// <summary>
        /// Navigation property representing the associated USER_NOTIFICATION
        /// </summary>
        [ForeignKey("GUID_USER_NOTIFICATION")]
        public USER_NOTIFICATION? GUID_USER_NOTIFICATION_USER_NOTIFICATION { get; set; }

        /// <summary>
        /// READ_DATE of the USER_X_USER_NOTIFICATION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? READ_DATE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the USER_X_USER_NOTIFICATION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the USER_X_USER_NOTIFICATION belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the USER_X_USER_NOTIFICATION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the USER_X_USER_NOTIFICATION belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}