using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a user_profile entity with essential details
    /// </summary>
    [Table("USER_PROFILE", Schema = "dbo")]
    public class USER_PROFILE
    {
        /// <summary>
        /// Initializes a new instance of the USER_PROFILE class.
        /// </summary>
        public USER_PROFILE()
        {
            IS_SYSTEM_ADMINISTRATOR = false;
            CAN_RUN_NEW_PERIOD = false;
            CREATION_DATE = DateTime.UtcNow;
            UPDATED_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the USER_PROFILE 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field IS_SYSTEM_ADMINISTRATOR of the USER_PROFILE 
        /// </summary>
        [Required]
        public bool IS_SYSTEM_ADMINISTRATOR { get; set; }

        /// <summary>
        /// Required field CAN_RUN_NEW_PERIOD of the USER_PROFILE 
        /// </summary>
        [Required]
        public bool CAN_RUN_NEW_PERIOD { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the USER_PROFILE belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the USER_PROFILE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the USER_PROFILE belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the USER_PROFILE belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the USER_PROFILE belongs 
        /// </summary>
        public Guid? GUID_USER { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER")]
        public USR? GUID_USER_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the ENTITY_PERMISSION_PROFILE to which the USER_PROFILE belongs 
        /// </summary>
        public Guid? GUID_ENTITY_PERMISSION_PROFILE { get; set; }

        /// <summary>
        /// Navigation property representing the associated ENTITY_PERMISSION_PROFILE
        /// </summary>
        [ForeignKey("GUID_ENTITY_PERMISSION_PROFILE")]
        public ENTITY_PERMISSION_PROFILE? GUID_ENTITY_PERMISSION_PROFILE_ENTITY_PERMISSION_PROFILE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the USER_PROFILE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
    }
}