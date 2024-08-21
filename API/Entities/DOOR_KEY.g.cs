using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a door_key entity with essential details
    /// </summary>
    [Table("DOOR_KEY", Schema = "dbo")]
    public class DOOR_KEY
    {
        /// <summary>
        /// Initializes a new instance of the DOOR_KEY class.
        /// </summary>
        public DOOR_KEY()
        {
            QUANTITY = 0;
            IN_STOCK = 0;
            TYPE = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the DOOR_KEY 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field QUANTITY of the DOOR_KEY 
        /// </summary>
        [Required]
        public int QUANTITY { get; set; }

        /// <summary>
        /// Required field IN_STOCK of the DOOR_KEY 
        /// </summary>
        [Required]
        public int IN_STOCK { get; set; }

        /// <summary>
        /// Required field TYPE of the DOOR_KEY 
        /// </summary>
        [Required]
        public int TYPE { get; set; }
        /// <summary>
        /// CODE of the DOOR_KEY 
        /// </summary>
        public string? CODE { get; set; }
        /// <summary>
        /// CABINET of the DOOR_KEY 
        /// </summary>
        public string? CABINET { get; set; }
        /// <summary>
        /// HOOK_NUMBER of the DOOR_KEY 
        /// </summary>
        public string? HOOK_NUMBER { get; set; }
        /// <summary>
        /// TAG of the DOOR_KEY 
        /// </summary>
        public string? TAG { get; set; }
        /// <summary>
        /// EXPLANATORY_TEXT of the DOOR_KEY 
        /// </summary>
        public string? EXPLANATORY_TEXT { get; set; }

        /// <summary>
        /// UPDATED_DATE of the DOOR_KEY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DOOR_KEY belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the DOOR_KEY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DOOR_KEY belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the DOOR_KEY belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the DOOR_KEY_SYSTEM to which the DOOR_KEY belongs 
        /// </summary>
        public Guid? GUID_DOOR_KEY_SYSTEM { get; set; }

        /// <summary>
        /// Navigation property representing the associated DOOR_KEY_SYSTEM
        /// </summary>
        [ForeignKey("GUID_DOOR_KEY_SYSTEM")]
        public DOOR_KEY_SYSTEM? GUID_DOOR_KEY_SYSTEM_DOOR_KEY_SYSTEM { get; set; }
        /// <summary>
        /// ID of the DOOR_KEY 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the DOOR_KEY 
        /// </summary>
        public string? DESCRIPTION { get; set; }
    }
}