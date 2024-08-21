using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a entity_permission entity with essential details
    /// </summary>
    [Table("ENTITY_PERMISSION", Schema = "dbo")]
    public class ENTITY_PERMISSION
    {
        /// <summary>
        /// Initializes a new instance of the ENTITY_PERMISSION class.
        /// </summary>
        public ENTITY_PERMISSION()
        {
            ENTITY_TYPE = -1;
            PARENT_ENTITY_TYPE = 0;
            PERMISSIONS = 0;
            NON_DATA_OWNER_PERMISSIONS = 0;
            MODULE_GROUP = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field ENTITY_TYPE of the ENTITY_PERMISSION 
        /// </summary>
        [Required]
        public int ENTITY_TYPE { get; set; }

        /// <summary>
        /// Required field PARENT_ENTITY_TYPE of the ENTITY_PERMISSION 
        /// </summary>
        [Required]
        public int PARENT_ENTITY_TYPE { get; set; }

        /// <summary>
        /// Required field PERMISSIONS of the ENTITY_PERMISSION 
        /// </summary>
        [Required]
        public int PERMISSIONS { get; set; }

        /// <summary>
        /// Required field NON_DATA_OWNER_PERMISSIONS of the ENTITY_PERMISSION 
        /// </summary>
        [Required]
        public int NON_DATA_OWNER_PERMISSIONS { get; set; }

        /// <summary>
        /// Primary key for the ENTITY_PERMISSION 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field MODULE_GROUP of the ENTITY_PERMISSION 
        /// </summary>
        [Required]
        public int MODULE_GROUP { get; set; }
        /// <summary>
        /// Foreign key referencing the ENTITY_PERMISSION_PROFILE to which the ENTITY_PERMISSION belongs 
        /// </summary>
        public Guid? GUID_ENTITY_PERMISSION_PROFILE { get; set; }

        /// <summary>
        /// Navigation property representing the associated ENTITY_PERMISSION_PROFILE
        /// </summary>
        [ForeignKey("GUID_ENTITY_PERMISSION_PROFILE")]
        public ENTITY_PERMISSION_PROFILE? GUID_ENTITY_PERMISSION_PROFILE_ENTITY_PERMISSION_PROFILE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the ENTITY_PERMISSION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENTITY_PERMISSION belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the ENTITY_PERMISSION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENTITY_PERMISSION belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}