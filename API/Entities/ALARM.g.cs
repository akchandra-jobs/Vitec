using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a alarm entity with essential details
    /// </summary>
    [Table("ALARM", Schema = "dbo")]
    public class ALARM
    {
        /// <summary>
        /// Initializes a new instance of the ALARM class.
        /// </summary>
        public ALARM()
        {
            ENTITY_TYPE = -1;
            IS_ENABLED = false;
            ACTION = 0;
            IS_ALLOWING_REENTRANCY = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field ENTITY_TYPE of the ALARM 
        /// </summary>
        [Required]
        public int ENTITY_TYPE { get; set; }

        /// <summary>
        /// Required field IS_ENABLED of the ALARM 
        /// </summary>
        [Required]
        public bool IS_ENABLED { get; set; }

        /// <summary>
        /// Primary key for the ALARM 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field ACTION of the ALARM 
        /// </summary>
        [Required]
        public int ACTION { get; set; }

        /// <summary>
        /// Required field IS_ALLOWING_REENTRANCY of the ALARM 
        /// </summary>
        [Required]
        public bool IS_ALLOWING_REENTRANCY { get; set; }
        /// <summary>
        /// COMMENT of the ALARM 
        /// </summary>
        public string? COMMENT { get; set; }
        /// <summary>
        /// ENTITY_UPDATE_PATTERN of the ALARM 
        /// </summary>
        public string? ENTITY_UPDATE_PATTERN { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the ALARM belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// ID of the ALARM 
        /// </summary>
        public string? ID { get; set; }

        /// <summary>
        /// UPDATED_DATE of the ALARM 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ALARM belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the ALARM 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ALARM belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// FIELD_NAME of the ALARM 
        /// </summary>
        public string? FIELD_NAME { get; set; }
        /// <summary>
        /// CONDITIONS of the ALARM 
        /// </summary>
        public string? CONDITIONS { get; set; }
        /// <summary>
        /// EMAIL_FROM of the ALARM 
        /// </summary>
        public string? EMAIL_FROM { get; set; }
        /// <summary>
        /// EMAIL_TO of the ALARM 
        /// </summary>
        public string? EMAIL_TO { get; set; }
        /// <summary>
        /// EMAIL_SUBJECT of the ALARM 
        /// </summary>
        public string? EMAIL_SUBJECT { get; set; }
        /// <summary>
        /// EMAIL_BODY of the ALARM 
        /// </summary>
        public string? EMAIL_BODY { get; set; }
    }
}