using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a door_key_x_door_lock entity with essential details
    /// </summary>
    [Table("DOOR_KEY_X_DOOR_LOCK", Schema = "dbo")]
    public class DOOR_KEY_X_DOOR_LOCK
    {
        /// <summary>
        /// Initializes a new instance of the DOOR_KEY_X_DOOR_LOCK class.
        /// </summary>
        public DOOR_KEY_X_DOOR_LOCK()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the DOOR_KEY_X_DOOR_LOCK 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the DOOR_KEY_X_DOOR_LOCK belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the DOOR_LOCK to which the DOOR_KEY_X_DOOR_LOCK belongs 
        /// </summary>
        public Guid? GUID_DOOR_LOCK { get; set; }

        /// <summary>
        /// Navigation property representing the associated DOOR_LOCK
        /// </summary>
        [ForeignKey("GUID_DOOR_LOCK")]
        public DOOR_LOCK? GUID_DOOR_LOCK_DOOR_LOCK { get; set; }
        /// <summary>
        /// Foreign key referencing the DOOR_KEY to which the DOOR_KEY_X_DOOR_LOCK belongs 
        /// </summary>
        public Guid? GUID_DOOR_KEY { get; set; }

        /// <summary>
        /// Navigation property representing the associated DOOR_KEY
        /// </summary>
        [ForeignKey("GUID_DOOR_KEY")]
        public DOOR_KEY? GUID_DOOR_KEY_DOOR_KEY { get; set; }

        /// <summary>
        /// UPDATED_DATE of the DOOR_KEY_X_DOOR_LOCK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DOOR_KEY_X_DOOR_LOCK belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the DOOR_KEY_X_DOOR_LOCK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DOOR_KEY_X_DOOR_LOCK belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}