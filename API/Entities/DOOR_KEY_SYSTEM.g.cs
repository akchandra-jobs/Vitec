using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a door_key_system entity with essential details
    /// </summary>
    [Table("DOOR_KEY_SYSTEM", Schema = "dbo")]
    public class DOOR_KEY_SYSTEM
    {
        /// <summary>
        /// Initializes a new instance of the DOOR_KEY_SYSTEM class.
        /// </summary>
        public DOOR_KEY_SYSTEM()
        {
            USE_UNIQUE_KEY_ID = false;
            IS_ESTATE_INDEPENDENT = false;
            ACCESS_SYSTEM_TYPE = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the DOOR_KEY_SYSTEM 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field USE_UNIQUE_KEY_ID of the DOOR_KEY_SYSTEM 
        /// </summary>
        [Required]
        public bool USE_UNIQUE_KEY_ID { get; set; }

        /// <summary>
        /// Required field IS_ESTATE_INDEPENDENT of the DOOR_KEY_SYSTEM 
        /// </summary>
        [Required]
        public bool IS_ESTATE_INDEPENDENT { get; set; }

        /// <summary>
        /// Required field ACCESS_SYSTEM_TYPE of the DOOR_KEY_SYSTEM 
        /// </summary>
        [Required]
        public int ACCESS_SYSTEM_TYPE { get; set; }
        /// <summary>
        /// MANUFACTURER of the DOOR_KEY_SYSTEM 
        /// </summary>
        public string? MANUFACTURER { get; set; }
        /// <summary>
        /// NOTE of the DOOR_KEY_SYSTEM 
        /// </summary>
        public string? NOTE { get; set; }
        /// <summary>
        /// Foreign key referencing the SUPPLIER to which the DOOR_KEY_SYSTEM belongs 
        /// </summary>
        public Guid? GUID_SUPPLIER { get; set; }

        /// <summary>
        /// Navigation property representing the associated SUPPLIER
        /// </summary>
        [ForeignKey("GUID_SUPPLIER")]
        public SUPPLIER? GUID_SUPPLIER_SUPPLIER { get; set; }
        /// <summary>
        /// Foreign key referencing the PERSON to which the DOOR_KEY_SYSTEM belongs 
        /// </summary>
        public Guid? GUID_RESPONSIBLE_PERSON { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERSON
        /// </summary>
        [ForeignKey("GUID_RESPONSIBLE_PERSON")]
        public PERSON? GUID_RESPONSIBLE_PERSON_PERSON { get; set; }

        /// <summary>
        /// UPDATED_DATE of the DOOR_KEY_SYSTEM 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DOOR_KEY_SYSTEM belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the DOOR_KEY_SYSTEM 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DOOR_KEY_SYSTEM belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the DOOR_KEY_SYSTEM belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the ESTATE to which the DOOR_KEY_SYSTEM belongs 
        /// </summary>
        public Guid? GUID_ESTATE { get; set; }

        /// <summary>
        /// Navigation property representing the associated ESTATE
        /// </summary>
        [ForeignKey("GUID_ESTATE")]
        public ESTATE? GUID_ESTATE_ESTATE { get; set; }
        /// <summary>
        /// ID of the DOOR_KEY_SYSTEM 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the DOOR_KEY_SYSTEM 
        /// </summary>
        public string? DESCRIPTION { get; set; }
    }
}