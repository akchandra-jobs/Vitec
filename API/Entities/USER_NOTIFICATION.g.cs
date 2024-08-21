using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a user_notification entity with essential details
    /// </summary>
    [Table("USER_NOTIFICATION", Schema = "dbo")]
    public class USER_NOTIFICATION
    {
        /// <summary>
        /// Initializes a new instance of the USER_NOTIFICATION class.
        /// </summary>
        public USER_NOTIFICATION()
        {
            ENTITY_TYPE = -1;
            TYPE = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the USER_NOTIFICATION 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field ENTITY_TYPE of the USER_NOTIFICATION 
        /// </summary>
        [Required]
        public int ENTITY_TYPE { get; set; }

        /// <summary>
        /// Required field TYPE of the USER_NOTIFICATION 
        /// </summary>
        [Required]
        public int TYPE { get; set; }

        /// <summary>
        /// HANDLED_DATE of the USER_NOTIFICATION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? HANDLED_DATE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the USER_NOTIFICATION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the USER_NOTIFICATION belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the USER_NOTIFICATION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the USER_NOTIFICATION belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// ID of the USER_NOTIFICATION 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the USER_NOTIFICATION 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the USER_NOTIFICATION belongs 
        /// </summary>
        public Guid? GUID_HANDLED_BY_USER { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_HANDLED_BY_USER")]
        public USR? GUID_HANDLED_BY_USER_USR { get; set; }
        /// <summary>
        /// GUID_ENTITY of the USER_NOTIFICATION 
        /// </summary>
        public Guid? GUID_ENTITY { get; set; }
    }
}