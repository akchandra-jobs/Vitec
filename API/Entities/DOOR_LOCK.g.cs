using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a door_lock entity with essential details
    /// </summary>
    [Table("DOOR_LOCK", Schema = "dbo")]
    public class DOOR_LOCK
    {
        /// <summary>
        /// Initializes a new instance of the DOOR_LOCK class.
        /// </summary>
        public DOOR_LOCK()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the DOOR_LOCK 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the DOOR_LOCK belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the DOOR_KEY_SYSTEM to which the DOOR_LOCK belongs 
        /// </summary>
        public Guid? GUID_DOOR_KEY_SYSTEM { get; set; }

        /// <summary>
        /// Navigation property representing the associated DOOR_KEY_SYSTEM
        /// </summary>
        [ForeignKey("GUID_DOOR_KEY_SYSTEM")]
        public DOOR_KEY_SYSTEM? GUID_DOOR_KEY_SYSTEM_DOOR_KEY_SYSTEM { get; set; }
        /// <summary>
        /// Foreign key referencing the CYLINDER_TYPE to which the DOOR_LOCK belongs 
        /// </summary>
        public Guid? GUID_CYLINDER_TYPE { get; set; }

        /// <summary>
        /// Navigation property representing the associated CYLINDER_TYPE
        /// </summary>
        [ForeignKey("GUID_CYLINDER_TYPE")]
        public CYLINDER_TYPE? GUID_CYLINDER_TYPE_CYLINDER_TYPE { get; set; }
        /// <summary>
        /// ID of the DOOR_LOCK 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the DOOR_LOCK 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// DOOR_NR of the DOOR_LOCK 
        /// </summary>
        public string? DOOR_NR { get; set; }
        /// <summary>
        /// NOTE of the DOOR_LOCK 
        /// </summary>
        public string? NOTE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the DOOR_LOCK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DOOR_LOCK belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the DOOR_LOCK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DOOR_LOCK belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}